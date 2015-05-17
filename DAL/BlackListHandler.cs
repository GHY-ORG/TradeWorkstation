using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    public class BlackListHandler : IBlackListHandler
    {
        public bool Create(BlackList blacklist)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    db.BlackList.InsertOnSubmit(blacklist);
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

        public IQueryable<BlackList> Show()
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.BlackList
                             select o;
                return result;
            }
        }

        public IQueryable<BlackList> ShowByUID(Guid uid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.BlackList
                             where o.UID == uid
                             select o;
                return result;
            }
        }

        public IQueryable<BlackList> ShowByIID(Guid iid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.BlackList
                             where o.IID == iid
                             select o;
                return result;
            }
        }
    }
}
