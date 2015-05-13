using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    /// <summary>
    /// 举报数据处理层接口
    /// </summary>
    interface IBlackListHandler
    {
        /// <summary>
        /// 用户添加举报
        /// </summary>
        /// <returns></returns>
        int Create(BlackList blacklist);
        /// <summary>
        /// 后台查看所有举报记录
        /// </summary>
        /// <returns></returns>
        List<BlackList> Show();
        /// <summary>
        /// 后台查看特定用户举报记录
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<BlackList> ShowByUID(Guid uid);
        /// <summary>
        /// 后台查看特定商品被举报记录
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        List<BlackList> ShowByIID(Guid iid);
    }
}
