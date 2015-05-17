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
        private static IPicHandler iph;
        public static bool InsertPic(HttpPostedFileBase file,string username,int type,Guid uid,int order,string path)
        {
            string filename = path + DateTime.Now.Ticks + ".jpeg";
             if (!System.IO.Directory.Exists(path))
                 System.IO.Directory.CreateDirectory(path);
             file.SaveAs(filename);
           // PicHandler ph =new PicHandler();
            Pic pic = new Pic();
            pic.Url = filename;
            pic.IID = uid;
            pic.Order = order;
            if (iph.Create(pic) == 1)
            {
                return true;
            }
            else return false;
             

        }
    }
}
