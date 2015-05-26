using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DataSource;

namespace TradeWorkstation.Controllers
{
    [RoutePrefix("Center")]
    public class CenterController : Controller
    {
        CenterService centerService = new CenterService();

        [Route("AddStore/Uid/{uid}/Iid/{iid}")]
        public ActionResult AddStore(string uid, string iid)
        {
            Store store = new Store();
            store.UID = new Guid(uid);
            store.IID = new Guid(iid);

            if (centerService.Create(store))
            {
                return Content("<script>alert('收藏成功');history.go(-1);</script>");
            }
            else
            {
                return Content("<script>alert('插入数据异常');history.go(-1);</script>");
            }
        }
    }
}