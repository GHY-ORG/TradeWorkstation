using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataSource;
using BLL;
using System.Web.Mvc;
using System.Text;
using System.IO;
using TradeWorkstation.Models;
namespace TradeWorkstation.Controllers
{
    public class BuyController : Controller
    {
        // GET: Buy
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Handler(BuyForm bf)
        {
            Item item = new Item();
            item.Title = bf.title;
            item.CID = bf.cid;
            item.UID = new user().uID;//此处通过session获取，赋值给user，再获取
            item.Type = 2;
            item.Price = bf.price;
            item.Detail = bf.detail;
            item.Bargain = bf.bargain;
            item.Tel = bf.tel;
            item.QQ = bf.qq;
            item.Way = bf.way;
           
            if (BuyService.InsertBuyForm(item))
            {
                return Content("<script type='text/javascript'>alert('您已经上传成功！');</script>");
            }
            else
            {
                return Content("<script type='text/javascript'>alert('上传失败，请刷新页面，填写必要的信息！');</script>");
            }
            
        }
        public ActionResult Search(int order, int cid, int page)
        {
            var vm = SellService.GetBuyList(order, cid, page);
            ViewData.Model = vm;
            return View();
        }
    }
}