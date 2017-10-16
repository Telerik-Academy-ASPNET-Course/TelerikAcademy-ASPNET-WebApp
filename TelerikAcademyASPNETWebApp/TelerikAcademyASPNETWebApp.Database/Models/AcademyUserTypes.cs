namespace TelerikAcademyASPNETWebApp.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AcademyUserTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AcademyUserTypes()
        {
            AcademyUsers = new HashSet<AcademyUsers>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string UserType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AcademyUsers> AcademyUsers { get; set; }
    }
}
