using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public class user_item_pic
    {
        public Guid IID { get; set; }
        public string Title { get; set; }
        public Guid UID { get; set; }
        public int Type { get; set; }
        public int CID { get; set; }
        public int Price { get; set; }
        public string Detail { get; set; }
        public int Bargin { get; set; }
        public int Priority { get; set; }
        public string Tel { get; set; }
        public string QQ { get; set; }
        public string Way { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime RunTime { get; set; }
        public DateTime PostTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Statue { get; set; }

        //从EF数据库获取的昵称
        public string NickName { get; set; }
        //从Pic表获取商品第一张图片的id
        public Guid PID { get; set; }
        //从Category表获取分类名称
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
