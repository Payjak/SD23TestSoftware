namespace SDQuizMaker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbiquestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbiquestion()
        {
            tbianswers = new HashSet<tbianswer>();
        }

        [Key]
        public int IQuestionID { get; set; }

        public string Question { get; set; }

        public string Explanation { get; set; }

        public int? InstanceID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbianswer> tbianswers { get; set; }

        public virtual tbinstance tbinstance { get; set; }
    }
}
