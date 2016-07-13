namespace SDQuizMaker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbtquestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbtquestion()
        {
            tbtanswers = new HashSet<tbtanswer>();
        }

        [Key]
        public int TQuestionID { get; set; }

        public int? TemplateID { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Explanation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbtanswer> tbtanswers { get; set; }

        public virtual tbtemplate tbtemplate { get; set; }
    }
}
