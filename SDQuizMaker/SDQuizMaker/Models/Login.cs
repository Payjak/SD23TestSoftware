using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace SDQuizMaker.Models
{
    [Table("tbuser")]
    public class Login
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccessLevel { get; set; }
    }
}