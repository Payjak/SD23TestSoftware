namespace SDQuizMaker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbtanswer
    {
        [Key]
        public int TAnswerID { get; set; }

        public string Text { get; set; }

        public bool? Correct { get; set; }

        public int? TQuestionID { get; set; }

        public virtual tbtquestion tbtquestion { get; set; }
    }
}
