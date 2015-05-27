using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataSource;
using BLL;

namespace TradeWorkstation.Controllers
{
    [RoutePrefix("Buy")]
    public class BuyController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Models.BuyForm bf)
        {
            if (!bf.agreement)
            {
                return Content("<script>alert('请同意协议');history.go(-1);</script>");
            }
            if (!ModelState.IsValid)
            {
                return Content("<script>alert('表单信息验证失败，请重新填写');</script>");
            }
            else
            {
                Item item = new Item();
                item.Title = bf.title;
                item.CID = bf.secondList == "0" ? Int32.Parse(bf.firstList) : Int32.Parse(bf.secondList);
                item.UID = new Guid("2d7588e8-f353-47ed-902b-7d8441f0de30");
                item.Detail = bf.detail;
                item.Tel = bf.tel;
                string qq = bf.qq;
                string tel = bf.tel;
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
                if (BuyService.InsertBuyForm(item))
                {
                    return Content("<script>alert('发布成功');location.href='Search/Page/1';</script>");
                }
                else
                {
                    return Content("<script>alert('插入数据出现异常');</script>");
                }
            }
        }

        [HttpGet]
        [Route("Search/Page/{page:int}")]
        public ActionResult Search(int page)
        {
            ViewData.Model = BuyService.Show(page);
            return View();
        }

        [HttpGet]
        [Route("Search/Cid/{cid}/Page/{page:int}")]
        public ActionResult Search(int cid, int page)
        {
            ViewData.Model = BuyService.Show(page);
            return View();
        }

        [HttpGet]
        [Route("Search/Input/{input}/Page/{page:int}")]
        public ActionResult Search(string input, int page)
        {
            var vm = BuyService.GetSearchList(input, page);
            ViewData.Model = vm;
            return View();
        }
    }
}