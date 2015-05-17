using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataSource;
using BLL;
using System.Text;
using TradeWorkstation.Models;
namespace TradeWorkstation.Controllers
{
    public class SellController : Controller
    {
        // GET: Sell
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Handler(SellForm sf,HttpPostedFileBase file)
        {
           
            if (!ModelState.IsValid || file == null) 
            {
                Response.StatusCode = 400;
                return new EmptyResult();
            }
            else
            {
                user u = new user();//从session处获得
                Item item = new Item();
                item.Title = sf.title;
                item.CID = sf.cid;
                item.UID = new user().uID;//此处通过session获取，赋值给user，再获取
                item.Type = 1;
                item.Price = sf.price;
                item.Detail = sf.detail;
                item.Bargain = sf.bargain;
                item.Tel = sf.tel;
                item.QQ = sf.qq;
                item.Way = sf.way;
              
                if (SellService.InsertSellForm(item)&&PicService.InsertPic(file,u.uNum,sf.type,u.uID,sf.order,GetPath(u.uName,sf.type)))
                {
                    return Content("<script type='text/javascript'>alert('您已经上传成功！');</script>");
                }
                else
                {
                    return Content("<script type='text/javascript'>alert('上传失败，请刷新页面，填写必要的信息！');</script>");
                }
            
            }
        }
        public ActionResult Search(int order,int cid,int page)
        {
            var vm = SellService.GetBuyList(order,cid,page);
            ViewData.Model = vm;
            return View();
        }
        private string GetPath(string uname, int type)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Server.MapPath("/UpLoadFiles/"));
            sb.Append(uname);
            sb.Append(@"/");
            sb.Append(type);
            sb.Append(@"/");
            return sb.ToString();
        }
    }
}