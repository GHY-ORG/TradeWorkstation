using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace Common
{
    public class Logger : ILogger
    {

        private static Logger _logger;
        private static Guid _sysguid = new Guid("881B5532-5F62-4267-972F-074853FE4BDE");

        public static Logger GetImpl()
        {
            _logger = _logger ?? new Logger();
            return _logger;
        }
        public bool AddLog(string msg)
        {
            return AddLog(_sysguid, 0, msg);
        }

        public bool AddLog(Guid uid, int type, string msg)
        {
            try
            {
                using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
                {
                    db.SysLog.InsertOnSubmit(new SysLog { LID = Guid.NewGuid(), UID = uid, LogContent = msg, LogTime = DateTime.Now, Type = type });
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
