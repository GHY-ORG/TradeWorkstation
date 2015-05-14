using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    public class OtherPoolHandler:IOtherPoolHandler
    {
        public int Create(DataSource.Item item)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    item.IID = Guid.NewGuid();
                    item.PostTime = DateTime.Now;
                    item.UpdateTime = DateTime.Now;
                    item.Status = 402;
                    db.Item.InsertOnSubmit(item);
                    db.SubmitChanges();
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }

        public List<DataSource.Item> Show()
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.Type == 4 && o.Status == 402
                             select o;
                return result.ToList<Item>();
            }
        }

        public List<DataSource.Item> ShowItemByUID(Guid uid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.UID == uid && o.Type == 4 && o.Status == 402
                             select o;
                return result.ToList<Item>();
            }
        }

        public DataSource.Item ShowItemInfo(Guid iid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.IID == iid && o.Status == 402
                             select o;
                return result.Single();
            }
        }

        public int ItemComplete(Guid iid)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    var result = from o in db.Item
                                 where o.IID == iid && o.Status == 402
                                 select o;
                    result.Single().Status = 403;
                    db.SubmitChanges();
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }

        public int ItemOverdue()
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    var result = from o in db.Item
                                 where o.Type == 4 && DateTime.Compare(DateTime.Now, o.EndTime) > 0 && o.Status == 402
                                 select o;
                    foreach (Item o in result)
                    {
                        o.Status = 401;
                    }
                    db.SubmitChanges();
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
    }
}
