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
        [Required]
        [DataType(DataType.Text)]
        [MinLength(1)]
        [MaxLength(50)]
        public string title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime runtime { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(1)]
        [MaxLength(100)]
        public string carFrom { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(1)]
        [MaxLength(100)]
        public string carTo { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(1)]
        public string detail { get; set; }

        [DataType(DataType.Text)]
        [MinLength(1)]
        [MaxLength(50)]
        public string qq { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "请填写正确格式手机号")]
        [MinLength(1)]
        [MaxLength(50)]
        public string tel { get; set; }
    }
}