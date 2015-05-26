using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    public class StoreHandler:IStoreHandler
    {

        public bool Create(Store store)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    store.SID = Guid.NewGuid();
                    store.StoreTime = DateTime.Now;
                    store.Status = 1;
                    db.Store.InsertOnSubmit(store);
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

        public List<Store> Show()
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Store
                             select o;
                return result.ToList<Store>();
            }
        }

        public List<Store> ShowByUID(Guid uid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Store
                             where o.UID == uid
                             select o;
                return result.ToList<Store>();
            }
        }

        public List<Store> ShowByIID(Guid iid)
        {
            using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
            {
                var result = from o in db.Store
                             where o.IID == iid
                             select o;
                return result.ToList<Store>();
            }
        }
    }
}
