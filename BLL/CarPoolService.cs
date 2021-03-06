﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataSource;

namespace BLL
{
    public class CarPoolService
    {
        DAL.CarPoolHandler carPoolHandler = new DAL.CarPoolHandler();

        /// <summary>
        /// 提交拼车表单信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(Item item)
        {
            return carPoolHandler.Create(item);
        }
        /// <summary>
        /// 显示所有未过期的拼车信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<user_item_pic> Show(int page, int n)
        {
            return carPoolHandler.Show(page, n);
        }
        /// <summary>
        /// 拼车检索
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="carFrom"></param>
        /// <param name="carTo"></param>
        /// <returns></returns>
        public List<user_item_pic> ShowItemByInfo(DateTime runtime, string carFrom, string carTo)
        {
            return carPoolHandler.ShowItemByInfo(runtime, carFrom, carTo);
        }
        /// <summary>
        /// 拼车标签检索
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<user_item_pic> ShowItemByTag(string tag, int page)
        {
            return carPoolHandler.ShowItemByTag(tag, page);
        }
        /// <summary>
        /// 根据IID显示拼车信息
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        public List<user_item_pic> ShowItemInfo(Guid iid)
        {
            return carPoolHandler.ShowItemInfo(iid);
        }
    }
}
