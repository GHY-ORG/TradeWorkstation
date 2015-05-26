using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data;
using DataSource;
using DAL;
namespace BLL
{
    public class PicService
    {
        private static IPicHandler iph = new PicHandler();
        public static bool InsertPic(Pic pic)
        {
            return iph.Create(pic);
        }
        public static List<Pic> ShowByIID(Guid iid)
        {
            return iph.ShowByIID(iid);
        }
        public static string GetPicUrl(Guid pid)
        {
            return iph.GetPicUrl(pid);
        }
    }
}
