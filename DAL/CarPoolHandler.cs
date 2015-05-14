using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    public class CarPoolHandler:ICarPoolHandler
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
                    item.Status = 302;
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
                             where o.Type == 3 && o.Status == 302
                             select o;
                return result.ToList<Item>();
            }
        }

        public List<DataSource.Item> ShowItemByUID(Guid uid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.UID == uid && o.Type == 3 && o.Status == 302
                             select o;
                return result.ToList<Item>();
            }
        }

        public List<DataSource.Item> ShowItemByFrom(string carfrom)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.From == carfrom && o.Type == 3 && o.Status == 302
                             select o;
                return result.ToList<Item>();
            }
        }

        public List<DataSource.Item> ShowItemByTo(string carto)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.To == carto && o.Type == 3 && o.Status == 302
                             select o;
                return result.ToList<Item>();
            }
        }

        public List<DataSource.Item> ShowItemByTime(DateTime runtime)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.RunTime == runtime && o.Type == 3 && o.Status == 302
                             select o;
                return result.ToList<Item>();
            }
        }

        public DataSource.Item ShowItemInfo(Guid iid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.IID == iid && o.Type == 3 && o.Status == 302
                             select o;
                return result.Single();
            }
        }

        public int DelItem(Guid iid)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    var result = from o in db.Item
                                 where o.IID == iid && o.Status == 302
                                 select o;
                    result.Single().Status = 301;
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
                                 where o.Type == 3 && DateTime.Compare(DateTime.Now, o.EndTime) > 0 && o.Status == 302
                                 select o;
                    foreach (Item o in result)
                    {
                        o.Status = 303;
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
