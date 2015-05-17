using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TradeWorkstation.Models
{
    public class CarForm
    {
        [Required(ErrorMessage = "标题必填")]
        [Display(Name="标题")]
        [DataType(DataType.Text)]
        [MinLength(1)]
        [MaxLength(50, ErrorMessage = "标题50字以内")]
        public string title { get; set; }

        [Required(ErrorMessage = "出发时间必填")]
        [Display(Name = "出发时间")]
        [DataType(DataType.DateTime)]
        public DateTime runtime { get; set; }

        [Required(ErrorMessage = "出发地必填")]
        [Display(Name = "出发地")]
        [DataType(DataType.Text)]
        [MinLength(1)]
        [MaxLength(100, ErrorMessage = "出发地100字以内")]
        public string carFrom { get; set; }

        [Required(ErrorMessage = "目的地必填")]
        [Display(Name = "目的地")]
        [DataType(DataType.Text)]
        [MinLength(1)]
        [MaxLength(100, ErrorMessage = "目的地100字以内")]
        public string carTo { get; set; }

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
    }
}