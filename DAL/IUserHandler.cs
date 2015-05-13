using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DAL
{
    /// <summary>
    /// 用户数据处理层接口
    /// </summary>
    interface IUserHandler
    {
        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Create(user user);
        /// <summary>
        /// 由学号注销用户
        /// </summary>
        /// <param name="usernum"></param>
        /// <returns></returns>
        int Del(string usernum);

        /// <summary>
        /// 由学号修改密码
        /// </summary>
        /// <param name="usernum"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        int UpdatePassword(string usernum, string password);
        /// <summary>
        /// 完善信息（昵称、邮箱、手机、年级、性别、头像、真实姓名）
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int UpdateUserInfo(user user);
        /// <summary>
        /// 根据学号 更新用户ip和登录时间
        /// </summary>
        /// <param name="usernum"></param>
        /// <returns></returns>
        int UpdateIPTime(string usernum);

        /// <summary>
        /// 根据UID获得user实体,不存在返回null
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        user SelectUserByUID(Guid uid);
        /// <summary>
        /// 根据昵称获得user实体,不存在返回null
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        user SelectUserByUName(string username);
        /// <summary>
        /// 根据学号获得user实体,不存在返回null
        /// </summary>
        /// <param name="usernum"></param>
        /// <returns></returns>
        user SelectUserByUNum(string usernum);
        /// <summary>
        /// 根据昵称和密码登录,错误在返回null
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        user LoginByUName(string username, string password);
        /// <summary>
        /// 根据学号和密码登录,错误在返回null
        /// </summary>
        /// <param name="usernum"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        user LoginByUNum(string usernum, string password);
        /// <summary>
        /// 根据学号查询UID,不存在返回Guid.Empty
        /// </summary>
        /// <param name="usernum"></param>
        /// <returns></returns>
        Guid SelectUIDByUNum(string usernum);
    }
}
