namespace SDQuizMaker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbresponse")]
    public partial class tbresponse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbresponse()
        {
            tbresponsedetails = new HashSet<tbresponsedetail>();
        }

        [Key]
        public int ResponseID { get; set; }

        public decimal? Score { get; set; }

        [StringLength(10)]
        public string UserID { get; set; }

        public int? InstanceID { get; set; }

        public virtual tbinstance tbinstance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbresponsedetail> tbresponsedetails { get; set; }

        public virtual tbuser tbuser { get; set; }
    }
}
