using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeWorkstation.Models;
using BLL;

namespace TradeWorkstation.Controllers
{
    [Export]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Import]
        public Hub.Interface.User.IAuthenticationStrategy AuthentiationStrategy { set; get; }

        [Import]
        public Hub.Interface.User.IAccountStrategy AccountStrategy { set; get; }

        public ActionResult Index()
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            Guid userid = new Guid(Session["User"].ToString());
            ViewBag.UserID = userid;
            ViewBag.NickName = AccountStrategy.GetNickNameByUserID(userid);

            //二货
            ViewData["class11"] = SellService.ShowItemByCID(11, 1, 4);//教科书
            ViewData["class12"] = SellService.ShowItemByCID(12, 1, 4);//考研用书
            ViewData["class13"] = SellService.ShowItemByCID(13, 1, 4);//考级考证
            ViewData["class14"] = SellService.ShowItemByCID(14, 1, 4);//课外书
            ViewData["class15"] = SellService.ShowItemByCID(17, 1, 4);//电脑
            ViewData["class16"] = SellService.ShowItemByCID(18, 1, 4);//平板

            ViewData["class21"] = SellService.ShowItemByCID(9, 1, 4);//自行车
            ViewData["class22"] = SellService.ShowItemByCID(30, 1, 4);//小电器
            ViewData["class23"] = SellService.ShowItemByCID(33, 1, 4);//化妆品
            ViewData["class24"] = SellService.ShowItemByCID(9, 1, 4);//服装.。。。。。这个是大类

            ViewData["class31"] = SellService.ShowItemByCID(32, 1, 4);//运动
            ViewData["class32"] = SellService.ShowItemByCID(16, 1, 4);//手机
            ViewData["class33"] = SellService.ShowItemByCID(20, 1, 4);//相机
            ViewData["class34"] = SellService.ShowItemByCID(21, 1, 4);//MP3\MP4
            ViewData["class35"] = SellService.ShowItemByCID(7, 1, 4);//虚拟物品
            ViewData["class36"] = SellService.ShowItemByCID(19, 1, 4);//游戏机

            //最新求购(显示7条)
            ViewData["buy"] = BuyService.Show(1);

            //最新求拼(3条拼车、3条拼其他)
            ViewData["car"] = new CarPoolService().Show(1,3);
            ViewData["other"] = new OtherPoolService().Show(1, 3);

            return View();
        }

        public ActionResult Publish()
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            Guid userid = new Guid(Session["User"].ToString());
            ViewBag.UserID = userid;
            ViewBag.NickName = AccountStrategy.GetNickNameByUserID(userid);
            return View();
        }
    }
}