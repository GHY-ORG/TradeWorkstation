﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    /// <summary>
    /// 求购数据处理层接口
    /// </summary>
    public interface IBuyHandler
    {
        /// <summary>
        /// 用户发布一条求购信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Create(Item item);
        /// <summary>
        /// 显示所有求购信息
        /// </summary>
        /// <returns></returns>
        List<user_item_pic> Show(int page);
        /// <summary>
        /// 显示用户自己的求购信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<Item> ShowItemByUID(Guid uid);
        /// <summary>
        /// 显示对应分类的求购信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        List<Item> ShowItemByCID(int cid, int page);
        /// <summary>
        /// 通过input显示求购信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        List<Item> ShowItemByInput(string input, int page);
        /// <summary>
        /// 查看具体的求购信息
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        Item ShowItemInfo(Guid iid);
        /// <summary>
        /// 用户将求购信息的状态改为完成 203
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        bool ItemComplete(Guid iid);
        /// <summary>
        /// 求购信息过期，系统自动将状态改为201
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        int ItemOverdue();

        List<Category> GetFirstName(int cid);

        string GetSecondName(int pid);
    }
}