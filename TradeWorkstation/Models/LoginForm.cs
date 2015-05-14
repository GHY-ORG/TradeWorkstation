using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace TradeWorkstation.Models
{
    
    public class LoginForm
    {
        [MaxLength(16)]
        [Required]
        public string UserName { get; set; }

    }
}