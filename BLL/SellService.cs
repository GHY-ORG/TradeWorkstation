﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
using DAL;

namespace BLL
{
    public class SellService
    {
        private static ISellHandler ish = new SellHandler();
        public static bool InsertSellForm(Item item)
        {
            return ish.Create(item);
        }
        public static List<user_item_pic> Show(int page, int n)
        {
            return ish.Show(page, n);
        }
        public static user_item_pic ShowDetail(Guid iid)
        {
            return ish.ShowDetail(iid);
        }
        public static List<user_item_pic> ShowItemByUID(Guid uid, int page, int n)
        {
            return ish.ShowItemByUID(uid,page, n);
        }
        public static List<user_item_pic> ShowItemByCID(int cid, int page, int n)
        {
            return ish.ShowItemByCID(cid,page,n);
        }
    }
}
