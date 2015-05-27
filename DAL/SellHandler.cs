using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    public class SellHandler : ISellHandler
    {
        public bool Create(Item item)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    //二手商品的IID需要在Controller那边生成
                    item.Type = 1;
                    item.PostTime = DateTime.Now;
                    item.UpdateTime = DateTime.Now;
                    item.EndTime = DateTime.Now.AddMonths(2);
                    item.Status = 102;
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
                List<Pic> picList = db.Pic.ToList<Pic>();
                var result = from item in itemList
                             join user in userList on item.UID equals user.UserID
                             join pic in picList on item.IID equals pic.IID
                             where (item.Type == 1) && (item.Status == 102) && (pic.Order == 1) && (pic.Status == 1)
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 IID = item.IID,
                                 NickName = user.ＮickName,
                                 Title = item.Title,
                                 Price = (int)item.Price,
                                 PID = pic.PID
                             };
                return result.Skip(8 * (page - 1)).Take(8).ToList<user_item_pic>();
            }
        }

        public user_item_pic ShowDetail(Guid iid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                GHYUsersDataContext db2 = new GHYUsersDataContext();
                List<User> userList = db2.User.ToList<User>();
                List<Item> itemList = db.Item.ToList<Item>();
                List<Pic> picList = db.Pic.ToList<Pic>();
                var result = from item in itemList
                             join user in userList on item.UID equals user.UserID
                             join pic in picList on item.IID equals pic.IID
                             where (item.IID == iid) && (pic.Order == 1) && (pic.Status == 1)
                             select new user_item_pic
                             {
                                 UID = user.UserID,
                                 NickName = user.ＮickName,
                                 Title = item.Title,
                                 CID = (int)item.CID,
                                 Detail = item.Detail,
                                 Price = (int)item.Price,
                                 PostTime = item.PostTime,
                                 QQ = item.QQ,
                                 Tel = item.Tel,
                                 PID = pic.PID
                             };
                return result.Single();
            }
        }

        public List<user_item_pic> ShowItemByUID(Guid uid, int page)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                GHYUsersDataContext db2 = new GHYUsersDataContext();
                List<User> userList = db2.User.ToList<User>();
                List<Item> itemList = db.Item.ToList<Item>();
                List<Pic> picList = db.Pic.ToList<Pic>();
                var result = from item in itemList
                             join user in userList on item.UID equals user.UserID
                             join pic in picList on item.IID equals pic.IID
                             where (user.UserID == uid) && (item.Type == 1) && (item.Status == 102) && (pic.Order == 1) && (pic.Status == 1)
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 IID = item.IID,
                                 Title = item.Title,
                                 PID = pic.PID
                             };
                return result.Skip(8*(page-1)).Take(8).ToList<user_item_pic>();
            }
        }

        public List<user_item_pic> ShowItemByCID(int cid, int page)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                GHYUsersDataContext db2 = new GHYUsersDataContext();
                List<User> userList = db2.User.ToList<User>();
                List<Item> itemList = db.Item.ToList<Item>();
                List<Pic> picList = db.Pic.ToList<Pic>();
                var result = from item in itemList
                             join user in userList on item.UID equals user.UserID
                             join pic in picList on item.IID equals pic.IID
                             where (item.CID == cid) && (item.Type == 1) && (item.Status == 102) && (pic.Order == 1) && (pic.Status == 1)
                             orderby item.PostTime descending
                             select new user_item_pic
                             {
                                 IID = item.IID,
                                 NickName = user.ＮickName,
                                 CID = (int)item.CID,
                                 Title = item.Title,
                                 Price = (int)item.Price,
                                 PID = pic.PID
                             };
                return result.Skip(8*(page-1)).Take(8).ToList<user_item_pic>();
            }
        }

        public bool ItemComplete(Guid iid)
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
    }
}
