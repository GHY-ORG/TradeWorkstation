using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
using Common;

namespace DAL
{
    public class UserHandler : IUserHandler
    {
        public int Create(DataSource.user user)
        {
            try
            {
                using (GHYUserDataContext db = new GHYUserDataContext())
                {
                    user.uID = new Guid();
                    user.uPwd = Md5.MD5_encrypt(user.uPwd);
                    user.registerTime = DateTime.Now;
                    user.lastLogin = DateTime.Now;
                    user.uIP = GetClientIP.GetIP();
                    user.state = 0;
                    db.user.InsertOnSubmit(user);
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

        public int Del(string usernum)
        {
            try
            {
                using (GHYUserDataContext db = new GHYUserDataContext())
                {
                    var result = from o in db.user
                                 where o.uNum == usernum && o.state == 0
                                 select o;
                    result.Single().state = 1;
                    db.SubmitChanges();
                }
                return 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }

        public int UpdatePassword(string usernum, string password)
        {
            try
            {
                using (GHYUserDataContext db = new GHYUserDataContext())
                {
                    var result = from o in db.user
                                 where o.uNum == usernum && o.state == 0
                                 select o;
                    result.Single().uPwd = password;
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

        public int UpdateUserInfo(DataSource.user user)
        {
            try
            {
                using (GHYUserDataContext db = new GHYUserDataContext())
                {
                    var result = from o in db.user
                                 where o.uID == user.uID && o.state == 0
                                 select o;
                    result.Single().uName = user.uName;
                    result.Single().uMail = user.uMail;
                    result.Single().uTel = user.uTel;
                    result.Single().uGrade = user.uGrade;
                    result.Single().uSex = user.uSex;
                    result.Single().uPic = user.uPic;
                    result.Single().trueName = user.trueName;
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

        public int UpdateIPTime(string usernum)
        {
            try
            {
                using (GHYUserDataContext db = new GHYUserDataContext())
                {
                    var result = from o in db.user
                                 where o.uNum == usernum && o.state == 0
                                 select o;
                    result.Single().uIP = GetClientIP.GetIP();
                    result.Single().lastLogin = DateTime.Now;
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

        public DataSource.user SelectUserByUID(Guid uid)
        {
            using (GHYUserDataContext db = new GHYUserDataContext())
            {
                var result = from o in db.user
                             where o.uID == uid && o.state == 0
                             select o;
                if (result.Count() > 0)
                {
                    return result.Single();
                }
                else
                {
                    return null;
                }
            }
        }

        public DataSource.user SelectUserByUName(string username)
        {
            using (GHYUserDataContext db = new GHYUserDataContext())
            {
                var result = from o in db.user
                             where o.uName == username && o.state == 0
                             select o;
                if (result.Count() > 0)
                {
                    return result.Single();
                }
                else
                {
                    return null;
                }
            }
        }

        public DataSource.user SelectUserByUNum(string usernum)
        {
            using (GHYUserDataContext db = new GHYUserDataContext())
            {
                var result = from o in db.user
                             where o.uNum == usernum && o.state == 0
                             select o;
                if (result.Count() > 0)
                {
                    return result.Single();
                }
                else
                {
                    return null;
                }
            }
        }

        public DataSource.user LoginByUName(string username, string password)
        {
            using (GHYUserDataContext db = new GHYUserDataContext())
            {
                var result = from o in db.user
                             where o.uName == username && o.uPwd == password && o.state == 0
                             select o;
                if (result.Count() > 0)
                {
                    return result.Single();
                }
                else
                {
                    return null;
                }
            }
        }

        public DataSource.user LoginByUNum(string usernum, string password)
        {
            using (GHYUserDataContext db = new GHYUserDataContext())
            {
                var result = from o in db.user
                             where o.uNum == usernum && o.uPwd == password && o.state == 0
                             select o;
                if (result.Count() > 0)
                {
                    return result.Single();
                }
                else
                {
                    return null;
                }
            }
        }

        public Guid SelectUIDByUNum(string usernum)
        {
            using (GHYUserDataContext db = new GHYUserDataContext())
            {
                var result = from o in db.user
                             where o.uNum == usernum && o.state == 0
                             select o;
                if (result.Count() > 0)
                {
                    return result.Single().uID;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }
    }
}
