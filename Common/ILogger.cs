using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface ILogger
    {
        /// <summary>
        /// 添加系统log
        /// </summary>
        /// <param name="msg">log信息</param>
        /// <returns></returns>
        bool AddLog(string msg);
        /// <summary>
        /// 添加log
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="type">log类型 0 系统log 1管理员log 2用户log</param>
        /// <param name="msg">log信息</param>
        /// <returns></returns>
        bool AddLog(Guid uid, int type, string msg);
    }
}
