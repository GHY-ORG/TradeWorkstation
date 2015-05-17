using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
using DAL;
namespace BLL
{
    public class BuyService
    {
        private static IBuyHandler ibh;
        public static bool InsertBuyForm(Item item)
        {
            //BuyHandler bh = new BuyHandler();
            if (ibh.Create(item) == 1)
            {
                return true;
            }
            else return false;
        }
        public static List<user_item_pic> GetBuyList(int order,int cid,int page)
        {

            return ibh.GetBuyList(order, cid, page);
        }
    }
}
