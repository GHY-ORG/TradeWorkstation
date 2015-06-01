using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using BLL;
using DataSource;
using TradeWorkstation.Models;

namespace TradeWorkstation.Controllers
{
    [Export]
    [RoutePrefix("Car")]
    public class CarController : Controller
    {
        [Import]
        public Hub.Interface.User.IAuthenticationStrategy AuthentiationStrategy { set; get; }

        [Import]
        public Hub.Interface.User.IAccountStrategy AccountStrategy { set; get; }

        CarPoolService carPoolService = new CarPoolService();

        #region 拼车表单提交
        [HttpGet]
        public ActionResult Add()
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            Guid userid = new Guid(Session["User"].ToString());
            ViewBag.UserID = userid;
            ViewBag.NickName = AccountStrategy.GetNickNameByUserID(userid);

            CarForm car = new CarForm();
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CarForm car)
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            Guid userid = new Guid(Session["User"].ToString());
            ViewBag.UserID = userid;
            ViewBag.NickName = AccountStrategy.GetNickNameByUserID(userid);

            if (!car.agreement)
            {
                return Content("<script>alert('请同意协议');history.go(-1);</script>");
            }
            if (!ModelState.IsValid)
            {
                return Content("<script>alert('表单信息验证失败，请重新填写');history.go(-1);</script>");
            }
            Item item = new Item();
            item.UID = new Guid(Session["User"].ToString());
            item.Title = car.title;
            item.RunTime = car.runtime;
            item.From = car.carFrom;
            item.To = car.carTo;
            item.Detail = car.detail;
            string qq = car.qq;
            string tel = car.tel;
            //判断QQ或手机至少填一项的那个东西....
            if (qq == null && tel == null)
            {
                return Content("<script>alert('QQ或手机至少填一项');history.go(-1);</script>");
            }
            else if (qq != null && tel == null)
            {
                item.QQ = qq;
            }
            else if (tel != null && qq == null)
            {
                item.Tel = tel;
            }
            else if (tel != null && qq != null)
            {
                item.QQ = qq;
                item.Tel = tel;
            }
            if (carPoolService.Create(item))
            {
                return Content("<script>alert('发布成功！');location.href='Search/Page/1';</script>");
            }
            else
            {
                return Content("<script>alert('插入数据出现异常');</script>");
            }
        }
        #endregion 拼车表单提交

        #region 拼车检索
        [HttpGet]
        [Route("Search/Page/{page:int}")]
        public ActionResult Search(int page)
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            Guid userid = new Guid(Session["User"].ToString());
            ViewBag.UserID = userid;
            ViewBag.NickName = AccountStrategy.GetNickNameByUserID(userid);

            ViewData.Model = carPoolService.Show(page,7);
            return View();
        }

        [HttpPost]
        [Route("Search")]
        public ActionResult Search(DateTime runtime, string from, string to)
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            Guid userid = new Guid(Session["User"].ToString());
            ViewBag.UserID = userid;
            ViewBag.NickName = AccountStrategy.GetNickNameByUserID(userid);

            ViewData.Model = carPoolService.ShowItemByInfo(runtime, from, to);
            return View();
        }

        [HttpGet]
        [Route("Search/Tag/{tag}/Page/{page:int}")]
        public ActionResult Search(string tag, int page)
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            Guid userid = new Guid(Session["User"].ToString());
            ViewBag.UserID = userid;
            ViewBag.NickName = AccountStrategy.GetNickNameByUserID(userid);

            ViewData.Model = carPoolService.ShowItemByTag(tag,page);
            return View();
        }

        [HttpGet]
        [Route("Search/IID/{iid}")]
        public ActionResult Search(string iid)
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            Guid userid = new Guid(Session["User"].ToString());
            ViewBag.UserID = userid;
            ViewBag.NickName = AccountStrategy.GetNickNameByUserID(userid);

            ViewData.Model = carPoolService.ShowItemInfo(new Guid(iid));
            return View();
        }
        #endregion 拼车检索
    }
}