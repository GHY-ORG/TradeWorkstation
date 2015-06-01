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
        private static IBuyHandler ibh = new BuyHandler();
        public static bool InsertBuyForm(Item item)
        {
            return ibh.Create(item);
        }
        public static List<user_item_pic> Show(int page)
        {
            return ibh.Show(page);
        }
        public static List<user_item_pic> ShowItemByCID(int cid, int page, int n)
        {
            return ibh.ShowItemByCID(cid, page, n);
        }
        public static List<user_item_pic> ShowItemInfo(Guid iid)
        {
            return ibh.ShowItemInfo(iid);
        }
        public static List<user_item_pic> GetSearchList(string input, int page)
        {
            return ibh.ShowItemByInput(input, page);
        }
        public static List<Category> GetFirstName(int cid)
        {
            return ibh.GetFirstName(cid);
        }
        public static string GetSecondName(int pid)
        {
            return ibh.GetSecondName(pid);
        }
    }
}
