﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    /// <summary>
    /// 二手数据处理层接口
    /// </summary>
    public interface ISellHandler
    {
        /// <summary>
        /// 用户发布一条二手信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Create(Item item);
        /// <summary>
        /// 显示所有二手信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        List<user_item_pic> Show(int page);
        /// <summary>
        /// 显示二手详情
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        user_item_pic ShowDetail(Guid iid);
        /// <summary>
        /// 显示用户所有二手信息
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        List<user_item_pic> ShowItemByUID(Guid uid, int page);
        /// <summary>
        /// 显示对应分类的二手信息
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        List<user_item_pic> ShowItemByCID(int cid, int page);
        /// <summary>
        /// 用户将二手信息的状态改为完成 103
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        bool ItemComplete(Guid iid);
        /// <summary>
        /// 二手商品信息过期，系统自动将状态改为 101
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        int ItemOverdue();
        /// <summary>
        /// 用户更新二手商品信息(Title Price Detail Tel QQ Way UpdateTime)
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        int UpdateItem(Item item);
    }
}
