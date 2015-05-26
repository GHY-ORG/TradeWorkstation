using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    /// <summary>
    /// 收藏数据处理层接口
    /// </summary>
    public interface IStoreHandler
    {
        /// <summary>
        /// 用户添加收藏
        /// </summary>
        /// <returns></returns>
        bool Create(Store blacklist);
        /// <summary>
        /// 后台查看所有收藏记录
        /// </summary>
        /// <returns></returns>
        List<Store> Show();
        /// <summary>
        /// 后台查看特定用户收藏记录
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<Store> ShowByUID(Guid uid);
        /// <summary>
        /// 后台查看特定商品被收藏记录
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        List<Store> ShowByIID(Guid iid);
    }
}