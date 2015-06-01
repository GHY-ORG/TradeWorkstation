using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataSource;

namespace BLL
{
    public class OtherPoolService
    {
        DAL.OtherPoolHandler otherPoolHandler = new DAL.OtherPoolHandler();

        /// <summary>
        /// 提交拼其他表单信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(Item item)
        {
            return otherPoolHandler.Create(item);
        }
        /// <summary>
        /// 分页显示拼其他信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<user_item_pic> Show(int page, int n)
        {
            return otherPoolHandler.Show(page, n);
        }
        /// <summary>
        /// 显示具体拼其他信息
        /// </summary>
        /// <param name="iid"></param>
        /// <returns></returns>
        public List<user_item_pic> ShowItemInfo(Guid iid)
        {
            return otherPoolHandler.ShowItemInfo(iid);
        }
    }
}
