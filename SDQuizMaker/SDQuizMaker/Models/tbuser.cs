namespace SDQuizMaker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbuser")]
    public partial class tbuser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbuser()
        {
            tbresponses = new HashSet<tbresponse>();
        }
        [Required]
        [Key]
        [StringLength(10)]
        public string UserID { get; set; }

        public string ClassID { get; set; }

        public string ProfilePic { get; set; }
        [Required]
        [StringLength(80)]
        [RegularExpression (@"[a-z0-9]+[_a-z0-9\.-]*[a-z0-9]+@robertsoncollege+(\.net+)", ErrorMessage ="Thats not a Robertson email")]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string AccessLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbresponse> tbresponses { get; set; }

        public virtual tbintake tbintake { get; set; }
    }
}
