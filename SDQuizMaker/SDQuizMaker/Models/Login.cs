using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace SDQuizMaker.Models
{
    [Table("tbuser")]
    public class Login
    {
        public int UserID { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccessLevel { get; set; }
    }
}