using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataSource;

namespace BLL
{
    public class CarPoolHandler
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
    }
}
