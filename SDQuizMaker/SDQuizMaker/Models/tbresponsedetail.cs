namespace SDQuizMaker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbresponsedetail")]
    public partial class tbresponsedetail
    {
        [Key]
        public int DetailID { get; set; }

        public int? ResponseID { get; set; }

        public int? IAnswerID { get; set; }

        public virtual tbianswer tbianswer { get; set; }

        public virtual tbresponse tbresponse { get; set; }
    }
}
