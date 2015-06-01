using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    /// <summary>
    /// 拼其他数据处理层接口
    /// </summary>
    interface IOtherPoolHandler
    {
        /// <summary>
        /// 用户发布一条拼其他信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Create(Item item);
        /// <summary>
        /// 显示所有拼其他信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        List<user_item_pic> Show(int page, int n);
        /// <summary>
        /// 显示用户自己的拼其他信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<user_item_pic> ShowItemByUID(Guid uid);
        /// <summary>
        /// 查看具体的拼其他信息
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        List<user_item_pic> ShowItemInfo(Guid iid);
        /// <summary>
        /// 用户将拼其他信息的状态改为完成 403
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        bool ItemComplete(Guid iid);
        /// <summary>
        /// 拼其他信息过期，系统自动将状态改为401
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        bool ItemOverdue();
    }
}
