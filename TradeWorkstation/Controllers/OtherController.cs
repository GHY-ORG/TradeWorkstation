using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DataSource;
using TradeWorkstation.Models;

namespace TradeWorkstation.Controllers
{
    [RoutePrefix("Other")]
    public class OtherController : Controller
    {
        OtherPoolService otherPoolService = new OtherPoolService();

        #region 拼其他表单提交
        [HttpGet]
        public ActionResult Add()
        {
            OtherForm other = new OtherForm();
            return View(other);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(OtherForm other)
        {
            if (!other.agreement)
            {
                return Content("<script>alert('请同意协议');history.go(-1);</script>");
            }
            if (!ModelState.IsValid)
            {
                return Content("<script>alert('表单信息验证失败，请重新填写');history.go(-1);</script>");
            }
            Item item = new Item();
            item.Title = other.title;
            DateTime? dateOrNull = other.endtime;
            if (dateOrNull != null)
            {
                item.EndTime = dateOrNull.Value;
            }
            else
            {
                //如果没填EndTime，默认为2个月
                item.EndTime = DateTime.Now.AddMonths(2);
            }
            item.Detail = other.detail;
            string qq = other.qq;
            string tel = other.tel;
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
            if (otherPoolService.Create(item))
            {
                return Content("<script>alert('发布成功！');location.href='Search/Page/1';</script>");
            }
            else
            {
                return Content("<script>alert('插入数据出现异常');</script>");
            }
        }
        #endregion 拼其他表单提交

        #region 拼其他检索
        [Route("Search/Page/{page:int}")]
        public ActionResult Search(int page)
        {
            ViewData.Model = otherPoolService.Show(page);
            return View();
        }
        #endregion 拼其他检索
    }
}