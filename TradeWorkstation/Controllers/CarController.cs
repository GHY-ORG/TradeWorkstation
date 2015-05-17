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
    public class CarController : Controller
    {
        CarPoolHandler carPoolHandler = new CarPoolHandler();

        [HttpGet]
        public ActionResult Add()
        {
            CarForm car = new CarForm();
            return View(car);
        }

        [HttpPost]
        public ActionResult Add(CarForm car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            Item item = new Item();
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
                return Content("<script>alert('QQ或手机至少填一项');</script>");
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

            return Content("<script>alert('Error~~');</script>");
        }
    }
}