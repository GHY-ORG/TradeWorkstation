using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeWorkstation.Models;
using DataSource;
using System.Text;
using BLL;
namespace TradeWorkstation.Controllers
{
    [RoutePrefix("Sell")]
    public class SellController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            SellForm sf = new SellForm();
            return View(sf);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Models.SellForm sf, IEnumerable<HttpPostedFileBase> files)
        {
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
                item.UID = new Guid("2d7588e8-f353-47ed-902b-7d8441f0de30");
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
                            string url = Server.MapPath("/UpLoadFiles/");
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
            ViewData.Model = SellService.Show(page);
            return View();
        }

        [HttpGet]
        [Route("Search/CID/{cid:int}/Page/{page:int}")]
        public ActionResult Search(int cid, int page)
        {
            ViewData.Model = SellService.ShowItemByCID(cid, page);
            return View();
        }

        [HttpGet]
        [Route("Detail/ID/{iid}")]
        public ActionResult Detail(Guid iid)
        {
            user_item_pic good = SellService.ShowDetail(iid);
            ViewData["good"] = good;
            ViewData["good_pics"] = PicService.ShowByIID(iid);
            ViewData["user_other_goods"] = SellService.ShowItemByUID(good.UID,1);
            ViewData["class_other_goods"] = SellService.ShowItemByCID(good.CID, 1);
            //good的第一张图片PID
            ViewData["first_pic"] = good.PID;
            return View();
        }
    }
}