using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TradeWorkstation.Models
{
    public class SellForm
    {
        [Required(ErrorMessage = "标题必填")]
        [Display(Name = "商品名称")]
        [DataType(DataType.Text)]
        [MinLength(1)]
        [MaxLength(50, ErrorMessage = "标题50字以内")]
        public string title { get; set; }

        [Required(ErrorMessage = "价格必填")]
        [Display(Name = "价格")]
        [DataType(DataType.Text)]
        public int price { get; set; }

        [Required(ErrorMessage = "详细信息必填")]
        [Display(Name = "详细信息")]
        [DataType(DataType.Text)]
        [MinLength(1)]
        public string detail { get; set; }

        [RegularExpression("[0-9]+")]
        [Display(Name = "QQ")]
        [MinLength(1)]
        [MaxLength(50, ErrorMessage = "QQ号50字以内")]
        public string qq { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "请填写正确格式手机号")]
        [Display(Name = "手机")]
        [MinLength(1)]
        [MaxLength(50, ErrorMessage = "手机号50字以内")]
        public string tel { get; set; }

        public string firstList { get; set; }

        public string secondList { get; set; }

        [Required(ErrorMessage = "请同意协议")]
        public bool agreement { get; set; }
    }
}