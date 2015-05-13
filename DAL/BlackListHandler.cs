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
        public int Create(DataSource.BlackList blacklist)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    db.BlackList.InsertOnSubmit(blacklist);
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

        public List<DataSource.BlackList> Show()
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.BlackList
                             select o;
                return result.ToList<BlackList>();
            }

        }

        public List<DataSource.BlackList> ShowByUID(Guid uid)
        {
            throw new NotImplementedException();
        }

        public List<DataSource.BlackList> ShowByIID(Guid iid)
        {
            throw new NotImplementedException();
        }
    }
}
