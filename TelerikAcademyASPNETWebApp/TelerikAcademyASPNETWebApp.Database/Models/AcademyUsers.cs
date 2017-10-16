namespace TelerikAcademyASPNETWebApp.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AcademyUsers
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        
        [StringLength(255)]
        public string Email { get; set; }

        public int UserType { get; set; }

        public virtual AcademyUserTypes AcademyUserTypes { get; set; }
    }
}
