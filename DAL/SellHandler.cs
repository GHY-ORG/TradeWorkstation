using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
   public  class SellHandler:ISellHandler
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
                    item.Status = 102;
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
                             where o.Type == 1 && o.Status == 102
                             select o;
                return result.ToList<Item>();
            }
        }

        public List<DataSource.Item> ShowItemByUID(Guid uid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.UID == uid && o.Type == 1 && o.Status == 102
                             select o;
                return result.ToList<Item>();
            }
        }

        public List<DataSource.Item> ShowItemByCID(int cid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.CID == cid && o.Type == 1 && o.Status == 102
                             select o;
                return result.ToList<Item>();
            }
        }

        public DataSource.Item ShowItemInfo(Guid iid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.IID == iid && o.Status == 102
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
                                 where o.IID == iid && o.Status == 102
                                 select o;
                    result.Single().Status = 103;
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
                                 where o.Type == 1 && DateTime.Compare(DateTime.Now, o.EndTime) > 0 && o.Status == 102
                                 select o;
                    foreach (Item o in result)
                    {
                        o.Status = 101;
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

        public int UpdateItem(Item item)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    var result = from o in db.Item
                                 where o.IID == item.IID && o.Status == 102
                                 select o;
                    result.Single().Title = item.Title;
                    result.Single().Price = item.Price;
                    result.Single().Detail = item.Detail;
                    result.Single().Tel = item.Tel;
                    result.Single().QQ = item.QQ;
                    result.Single().Way = item.Way;
                    result.Single().UpdateTime = DateTime.Now;
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
       //用于search
        public List<user_item_pic> GetSellList(int order,int cid,int page)
        {
            using(TradeWorkstationDataContext db =new TradeWorkstationDataContext()){
                using(GHYUserDataContext gdc =new GHYUserDataContext()){
                    var result = from a in db.Item
                                 join b in db.Pic on a.IID equals b.IID
                                 join c in gdc.user on a.UID equals c.uID
                                 where (b.Order == 1) && (a.CID == cid) &&(a.Type ==1)
                                 select new user_item_pic
                                 {
                                     uName = c.uName,
                                     Title = a.Title,
                                     Url = b.Url,
                                     Price = a.Price.ToString(),
                                     PostTime = a.PostTime,
                                     Detail = a.Detail
                                 };
                    return result.Skip((page-1)*5).Take(5).ToList<user_item_pic>();
                }
            }
        }
    }
}
