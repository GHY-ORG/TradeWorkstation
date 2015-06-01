using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Caching;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;

namespace TradeWorkstation.Controllers
{
    [RoutePrefix("PicPool")]
    public class PicPoolController : Controller
    {
        static Cache cache = HttpRuntime.Cache;
        // GET: PicPool
        public ActionResult Index()
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">图片的guid</param>
        /// <param name="size">300x600 0x0是原图</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/ID/{id}/Size/{size}")]
        public ActionResult Get(string id, string size)
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            var width = Int32.Parse(size.Split('x')[0]);
            var height = Int32.Parse(size.Split('x')[1]);
            Image img;

            if (cache[id] != null)
            {
                img = cache[id] as Image;
            }
            else
            {
                var path = BLL.PicService.GetPicUrl(new Guid(id));
                if (!System.IO.File.Exists(path)) return HttpNotFound();
                else
                {
                    img = Bitmap.FromFile(path);
                    cache.Add(id, img, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20), CacheItemPriority.Normal, null);
                }
            }
            Bitmap bmp;
            if (width == 0 || height == 0)
            {
                bmp = new Bitmap(img);
            }
            else
            {
                bmp = new Bitmap(img, width, height);
            }

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);

            var result = ms.ToArray();
            ms.Dispose();
            Response.AddHeader("Cache-Control", "cache, store, must-revalidate");
            return File(result, "image/jpg");
        }
    }
}