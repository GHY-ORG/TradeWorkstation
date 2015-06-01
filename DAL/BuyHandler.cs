using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    public class BuyHandler : IBuyHandler
    {
        public bool Create(DataSource.Item item)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    item.IID = Guid.NewGuid();
                    item.Type = 2;
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

        public List<user_item_pic> Show(int page)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                GHYUsersDataContext db2 = new GHYUsersDataContext();
                List<User> userList = db2.User.ToList<User>();
                List<Item> itemList = db.Item.ToList<Item>();
                var result = from item in itemList
                             join user in userList on item.UID equals user.UserID
                             where (item.Type == 2) && (item.Status == 202)
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 IID = item.IID,
                                 NickName = user.NickName,
                                 Title = item.Title,
                                 Detail = item.Detail,
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
                             where (user.UserID == uid) && (item.Type == 2) && (item.Status == 202)
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 IID = item.IID,
                                 Title = item.Title,
                                 Detail = item.Detail,
                                 PostTime = item.PostTime,
                                 NickName = user.NickName
                             };
                return result.ToList<user_item_pic>();
            }
        }

        public List<user_item_pic> ShowItemByCID(int cid, int page, int n)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                GHYUsersDataContext db2 = new GHYUsersDataContext();
                List<User> userList = db2.User.ToList<User>();
                List<Item> itemList = db.Item.ToList<Item>();
                var result = from item in itemList
                             join user in userList on item.UID equals user.UserID
                             where (item.CID == cid) && (item.Type == 2) && (item.Status == 202)
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 IID = item.IID,
                                 NickName = user.NickName,
                                 CID = (int)item.CID,
                                 Title = item.Title,
                                 Detail = item.Detail,
                                 PostTime = item.PostTime
                             };
                return result.Skip(n * (page - 1)).Take(n).ToList<user_item_pic>();
            }
        }

        public List<user_item_pic> ShowItemByInput(string input, int page)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                GHYUsersDataContext db2 = new GHYUsersDataContext();
                List<User> userList = db2.User.ToList<User>();
                List<Item> itemList = db.Item.ToList<Item>();
                var result = from item in itemList
                             join user in userList on item.UID equals user.UserID
                             where (item.Title.IndexOf(input) != -1 || item.Detail.IndexOf(input) != -1) && item.Type == 2 && item.Status == 202
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 IID = item.IID,
                                 NickName = user.NickName,
                                 CID = (int)item.CID,
                                 Title = item.Title,
                                 Detail = item.Detail,
                                 PostTime = item.PostTime
                             };
                return result.Skip(7 * (page - 1)).Take(7).ToList<user_item_pic>();
            }
        }

        public List<user_item_pic> ShowItemInfo(Guid iid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                GHYUsersDataContext db2 = new GHYUsersDataContext();
                List<User> userList = db2.User.ToList<User>();
                List<Item> itemList = db.Item.ToList<Item>();
                var result = from item in itemList
                             join user in userList on item.UID equals user.UserID
                             where (item.IID == iid) && (item.Type == 2) && (item.Status == 202)
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 IID = item.IID,
                                 Title = item.Title,
                                 Detail = item.Detail,
                                 PostTime = item.PostTime,
                                 NickName = user.NickName,
                                 QQ = item.QQ,
                                 Tel = item.Tel
                             };
                return result.ToList<user_item_pic>();
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

        public int ItemOverdue()
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    var result = from o in db.Item
                                 where o.Type == 2 && DateTime.Compare(DateTime.Now, o.EndTime) > 0 && o.Status == 202
                                 select o;
                    foreach (Item o in result)
                    {
                        o.Status = 201;
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

        public List<Category> GetFirstName(int cid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Category
                             where o.CID == cid
                             select o;
                return result.ToList<Category>();
            }
        }

        public string GetSecondName(int pid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Category
                             where o.CID == pid
                             select o;
                return result.Single().Name;
            }
        }
    }
}