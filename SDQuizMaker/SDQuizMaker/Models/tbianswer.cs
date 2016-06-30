namespace SDQuizMaker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbianswer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbianswer()
        {
            tbresponsedetails = new HashSet<tbresponsedetail>();
        }

        [Key]
        public int IAnswerID { get; set; }

        public string Text { get; set; }

        public bool? Correct { get; set; }

        public int? IQuestionID { get; set; }

        public virtual tbiquestion tbiquestion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbresponsedetail> tbresponsedetails { get; set; }
    }
}
