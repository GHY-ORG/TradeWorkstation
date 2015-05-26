using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
using DAL;
namespace BLL
{
    public class CenterService
    {
        DAL.StoreHandler storeHandler = new StoreHandler();
        /// <summary>
        /// 插入一条收藏
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public bool Create(Store store)
        {
            return storeHandler.Create(store);
        }
    }
}
