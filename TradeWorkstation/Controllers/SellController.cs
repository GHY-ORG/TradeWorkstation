using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeWorkstation.Models;
using DataSource;
using System.Text;
using BLL;
namespace TradeWorkstation.Controllers
{
    [Export]
    [RoutePrefix("Sell")]
    public class SellController : Controller
    {
        [Import]
        public Hub.Interface.User.IAuthenticationStrategy AuthentiationStrategy { set; get; }

        [Import]
        public Hub.Interface.User.IAccountStrategy AccountStrategy { set; get; }

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

            SellForm sf = new SellForm();
            return View(sf);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Models.SellForm sf, IEnumerable<HttpPostedFileBase> files)
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            Guid userid = new Guid(Session["User"].ToString());
            ViewBag.UserID = userid;
            ViewBag.NickName = AccountStrategy.GetNickNameByUserID(userid);

            if (!sf.agreement)
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
                item.IID = Guid.NewGuid();
                item.Title = sf.title;
                item.CID = sf.secondList == "0" ? Int32.Parse(sf.firstList) : Int32.Parse(sf.secondList);
                item.UID = new Guid(Session["User"].ToString());
                item.Price = sf.price;
                item.Detail = sf.detail;
                item.Bargain = 1;
                item.Priority = 1;
                item.Way = "在线支付";
                string qq = sf.qq;
                string tel = sf.tel;
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
                int order = 0;
                int count = 0;
                if (BLL.SellService.InsertSellForm(item))
                {
                    if (files.Count() > 5)
                    {
                        return Content("<script>alert('最多上传5张图片！');</script>");
                    }
                    foreach (var file in files)
                    {
                        //每张图不超过2M
                        if (file != null && file.ContentLength > 0 && file.ContentLength < 1024*1024*2)
                        {
                            order++;
                            string[] lastname = file.FileName.Split('.');
                            string url = Server.MapPath("/TradeWorkstationImages/"+item.UID+"/");
                            Pic pic = new Pic();
                            pic.Order = order;
                            pic.IID = item.IID;
                            if (!System.IO.Directory.Exists(url))
                                System.IO.Directory.CreateDirectory(url);
                            url += DateTime.Now.Ticks + "." + lastname[1];
                            file.SaveAs(url);
                            pic.Url = url;
                            if (BLL.PicService.InsertPic(pic))
                            {
                                count++;
                            }
                        }
                        else
                        {
                            Response.StatusCode = 400;
                            return Content("<script>alert('您未选择图片');</script>");
                        }
                    }//foreach end
                }
                else
                {
                    return Content("<script>alert('物品信息保存失败'+'" + order + "');</script>");
                }
                if (count == order)
                {
                    // if (BLL.SellService.InsertSellForm(item))
                    return Content("<script>alert('上传成功');location.href='Search/Page/1'</script>");
                    // else
                    //   return Content("<script>alert('物品信息保存失败'+'"+order+"');</script>");
                }
                else
                {
                    return Content("<script>alert('上传失败啊啊啊'+'" + order + "');</script>");
                }
            }

        }
        
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

            ViewData.Model = SellService.Show(page, 8);
            return View();
        }

        [HttpGet]
        [Route("Search/CID/{cid:int}/Page/{page:int}")]
        public ActionResult Search(int cid, int page)
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            Guid userid = new Guid(Session["User"].ToString());
            ViewBag.UserID = userid;
            ViewBag.NickName = AccountStrategy.GetNickNameByUserID(userid);

            ViewData.Model = SellService.ShowItemByCID(cid, page, 8);//一页放8个
            return View();
        }

        [HttpGet]
        [Route("Detail/ID/{iid}")]
        public ActionResult Detail(Guid iid)
        {
            //用户
            if (Session["User"] == null)
            {
                return Redirect("~/User/PostLogin");
            }
            Guid userid = new Guid(Session["User"].ToString());
            ViewBag.UserID = userid;
            ViewBag.NickName = AccountStrategy.GetNickNameByUserID(userid);

            user_item_pic good = SellService.ShowDetail(iid);
            ViewData["good"] = good;
            ViewData["good_pics"] = PicService.ShowByIID(iid);
            ViewData["user_other_goods"] = SellService.ShowItemByUID(good.UID, 1, 5);//最多显示4个(不包括当前商品，所以取了5个，这个在view里面有判断)
            ViewData["class_other_goods"] = SellService.ShowItemByCID(good.CID, 1, 5);//同上
            //good的第一张图片PID
            ViewData["first_pic"] = good.PID;
            return View();
        }
    }
}