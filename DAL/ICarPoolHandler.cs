using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    /// <summary>
    /// 拼车数据处理层接口
    /// </summary>
    interface ICarPoolHandler
    {
        /// <summary>
        /// 用户发布一条拼车信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Create(Item item);

        /// <summary>
        /// 显示所有拼车信息
        /// </summary>
        /// <returns></returns>
        IQueryable<Item> Show();
        /// <summary>
        /// 显示用户自己的拼车信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        IQueryable<Item> ShowItemByUID(Guid uid);
        /// <summary>
        /// 根据出发地查询拼车信息
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        IQueryable<Item> ShowItemByFrom(string carfrom);
        /// <summary>
        /// 根据目的地查询拼车信息
        /// </summary>
        /// <param name="carto"></param>
        /// <returns></returns>
        IQueryable<Item> ShowItemByTo(string carto);
        /// <summary>
        /// 根据出发时间查询拼车信息
        /// </summary>
        /// <param name="runtime"></param>
        /// <returns></returns>
        IQueryable<Item> ShowItemByTime(DateTime runtime);
        /// <summary>
        /// 查看具体的求购信息
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        Item ShowItemInfo(Guid iid);
        /// <summary>
        /// 用户删除拼车信息 301
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        bool DelItem(Guid iid);
        /// <summary>
        /// 拼车信息过期，系统自动将状态改为 303
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        bool ItemOverdue();
    }
}
