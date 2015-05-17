using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public class user_item_pic
    {
        public string uName { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Price { get; set; }
        public DateTime PostTime { get; set; }
        public string Detail { get; set; }
        public user_item_pic(string _uName,string _Title,string _Url,string _Price,DateTime _PostTime,string _Detail)
        {
            uName = _uName;
            Title = _Title;
            Url = _Url;
            Price = _Price;
            PostTime = _PostTime;
            Detail = _Detail;

        }

        public user_item_pic()
        {
            // TODO: Complete member initialization
        }

        
    }
}
