using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataSource;
namespace BLL
{
    public class SellService
    {
        private static ISellHandler ish;
        public static bool InsertSellForm(Item item)
        {
            //SellHandler sh = new SellHandler();
            if (ish.Create(item) == 1)
            {
                return true;
            }
            else return false;
        }
         public static List<user_item_pic> GetBuyList(int order,int cid,int page)
        {
    
           return ish.GetSellList(order,cid,page);
        }
    }
}
