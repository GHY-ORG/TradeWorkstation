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
        public bool Create(Item item)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    item.IID = Guid.NewGuid();
                    item.Type = 3;
                    item.PostTime = DateTime.Now;
                    item.UpdateTime = DateTime.Now;
                    DateTime? dateOrNull = item.RunTime;
                    if (dateOrNull != null)
                    {
                        item.EndTime  = dateOrNull.Value;
                    }
                    item.Status = 302;
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
                             where (item.Type == 3) && (item.Status == 302)
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 NickName = user.ＮickName,
                                 Title = item.Title,
                                 Detail = item.Detail,
                                 RunTime = (DateTime)item.RunTime,
                                 From = item.From,
                                 To = item.To,
                                 PostTime = item.PostTime,
                                 QQ = item.QQ,
                                 Tel = item.Tel
                             };
                return result.Skip(7 * (page - 1)).Take(7).ToList<user_item_pic>();
            }
        }

        public List<user_item_pic> ShowItemByUID(Guid uid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                GHYUsersDataContext db2 = new GHYUsersDataContext();
                List<User> userList = db2.User.ToList<User>();
                List<Item> itemList = db.Item.ToList<Item>();
                var result = from item in itemList
                             join user in userList on item.UID equals user.UserID
                             where (item.Type == 3) && (item.Status == 302) && (item.UID == uid)
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 NickName = user.ＮickName,
                                 Title = item.Title,
                                 Detail = item.Detail,
                                 RunTime = (DateTime)item.RunTime,
                                 From = item.From,
                                 To = item.To,
                                 PostTime = item.PostTime,
                                 QQ = item.QQ,
                                 Tel = item.Tel
                             };
                return result.ToList<user_item_pic>();
            }
        }

        public List<user_item_pic> ShowItemByInfo(DateTime runtime, string carFrom, string carTo)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                GHYUsersDataContext db2 = new GHYUsersDataContext();
                List<User> userList = db2.User.ToList<User>();
                List<Item> itemList = db.Item.ToList<Item>();
                var result = from item in itemList
                             join user in userList on item.UID equals user.UserID
                             where item.Type == 3 && item.Status == 302 && item.RunTime == runtime && item.From.IndexOf(carFrom) != -1 && item.To.IndexOf(carTo) != -1
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 NickName = user.ＮickName,
                                 Title = item.Title,
                                 Detail = item.Detail,
                                 RunTime = (DateTime)item.RunTime,
                                 From = item.From,
                                 To = item.To,
                                 PostTime = item.PostTime,
                                 QQ = item.QQ,
                                 Tel = item.Tel
                             };
                return result.ToList<user_item_pic>();
            }
        }

        public List<user_item_pic> ShowItemByTag(string tag, int page)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                using (GHYUsersDataContext db2 = new GHYUsersDataContext())
                {
                    List<User> userList = db2.User.ToList<User>();
                    List<Item> itemList = db.Item.ToList<Item>();
                    var result = from item in itemList
                                 join user in userList on item.UID equals user.UserID
                                 where item.Type == 3 && item.Status == 302 && (tag.IndexOf(item.From) != -1 || tag.IndexOf(item.To) != -1)
                                 orderby item.PostTime descending
                                 select new user_item_pic
                                 {
                                     NickName = user.ＮickName,
                                     Title = item.Title,
                                     Detail = item.Detail,
                                     RunTime = (DateTime)item.RunTime,
                                     From = item.From,
                                     To = item.To,
                                     PostTime = item.PostTime,
                                     QQ = item.QQ,
                                     Tel = item.Tel
                                 };
                    return result.Skip(7 * (page - 1)).Take(7).ToList<user_item_pic>();
                }
            }
        }

        public Item ShowItemInfo(Guid iid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Item
                             where o.IID == iid && o.Type == 3 && o.Status == 302
                             select o;
                return result.Single();
            }
        }

        public bool DelItem(Guid iid)
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
                                 where o.Type == 3 && DateTime.Compare(DateTime.Now, o.EndTime) > 0 && o.Status == 302
                                 select o;
                    foreach (Item o in result)
                    {
                        o.Status = 303;
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
