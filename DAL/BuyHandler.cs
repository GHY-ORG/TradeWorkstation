using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    public class BuyHandler:IBuyHandler
    {
        public bool Create(DataSource.Item item)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    item.IID = Guid.NewGuid();
                    item.PostTime = DateTime.Now;
                    item.UpdateTime = DateTime.Now;
                    item.EndTime = DateTime.Now.AddMonths(2);
                    item.Status = 202;
                    db.Item.InsertOnSubmit(item);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public IQueryable<Item> Show()
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.Type == 2 && o.Status == 202
                             select o;
                return result;
            }
        }

        public IQueryable<Item> ShowItemByUID(Guid uid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.UID == uid && o.Type == 2 && o.Status == 202
                             select o;
                return result;
            }
        }

        public IQueryable<Item> ShowItemByCID(int cid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.CID == cid && o.Type == 2 && o.Status == 202
                             select o;
                return result;
            }
        }

        public Item ShowItemInfo(Guid iid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.IID == iid && o.Status == 202
                             select o;
                return result.Single();
            }
        }

        public bool ItemComplete(Guid iid)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    var result = from o in db.Item
                                 where o.IID == iid && o.Status == 202
                                 select o;
                    result.Single().Status = 203;
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool ItemOverdue()
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    var result = from o in db.Item
                                 where o.Type == 2 && DateTime.Compare(DateTime.Now, o.EndTime) > 0 && o.Status == 202
                                 select o;
                    foreach(Item o in result)
                    {
                        o.Status = 201;
                    }
                    db.SubmitChanges();
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return true;
            }
        }
        public List<user_item_pic> GetBuyList(int order,int cid,int page)
        { 
            using(TradeWorkstationDataContext db =new TradeWorkstationDataContext()){
                using(GHYUserDataContext gdc =new GHYUserDataContext()){
                    var result = from a in db.Item
                                 join b in db.Pic on a.IID equals b.IID
                                 join c in gdc.user on a.UID equals c.uID
                                 where (b.Order == 1) && (a.CID == cid) &&(a.Type==2)
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
