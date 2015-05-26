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
        public bool Create(Item item)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    item.IID = Guid.NewGuid();
                    item.Type = 4;
                    item.PostTime = DateTime.Now;
                    item.UpdateTime = DateTime.Now;
                    item.Status = 402;
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

        public List<user_item_pic> Show(int page)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                GHYUsersDataContext db2 = new GHYUsersDataContext();
                List<User> userList = db2.User.ToList<User>();
                List<Item> itemList = db.Item.ToList<Item>();
                var result = from item in itemList
                             join user in userList on item.UID equals user.UserID
                             where (item.Type == 4) && (item.Status == 402)
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 NickName = user.ＮickName,
                                 Title = item.Title,
                                 Detail = item.Detail,
                                 PostTime = item.PostTime,
                                 QQ = item.QQ,
                                 Tel = item.Tel
                             };
                return result.Skip(7 * (page - 1)).Take(7).ToList<user_item_pic>();
            }
        }

        public List<Item> ShowItemByUID(Guid uid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.UID == uid && o.Type == 4 && o.Status == 402
                             select o;
                return result.ToList<Item>();
            }
        }

        public Item ShowItemInfo(Guid iid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.IID == iid && o.Status == 402
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
                                 where o.IID == iid && o.Status == 402
                                 select o;
                    result.Single().Status = 403;
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
                                 where o.Type == 4 && DateTime.Compare(DateTime.Now, o.EndTime) > 0 && o.Status == 402
                                 select o;
                    foreach (Item o in result)
                    {
                        o.Status = 401;
                    }
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
    }
}
