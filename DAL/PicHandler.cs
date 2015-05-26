using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
namespace DAL
{
    public class PicHandler : IPicHandler
    {
        public bool Create(Pic pic)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    pic.PID = Guid.NewGuid();
                    pic.Status = 1;
                    db.Pic.InsertOnSubmit(pic);
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

        public List<Pic> ShowByIID(Guid iid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from a in db.Pic
                             where a.IID == iid
                             where a.Status > 0
                             orderby a.Order ascending
                             select a;
                return result.ToList<Pic>();
            }
        }

        public string GetPicUrl(Guid pid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from a in db.Pic
                             where a.PID == pid
                             select a;
                return result.Single().Url;
            }
        }
    }
}
