using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TradeWorkstation.Models
{
    public class BuyForm
    {

        [Required]
        [DataType(DataType.Text)]
        [MinLength(1)]
        [MaxLength(50)]
        public string title { get; set; }
        [Required]
        [DataType(DataType.Custom)]
        public int cid { get; set; }
        [Required]
        public int type { get; set; }
        [Required]
        [DataType(DataType.Custom)]
        [Range(typeof(decimal),"0.0000","999999.0000")]
        public decimal price { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MinLength(1)]
        public string detail { get; set; }
        [Required]
        [DataType(DataType.Custom)]
        public int bargain { get; set; }

        [MaxLength(50)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "请填写正确格式手机号")]
      
        public string tel { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Text)]
      
        public string qq { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Text)]
     
        public string way { get; set; }


    }
}