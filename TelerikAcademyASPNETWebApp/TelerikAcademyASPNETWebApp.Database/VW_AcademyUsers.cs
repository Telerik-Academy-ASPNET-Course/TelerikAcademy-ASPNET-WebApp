namespace TelerikAcademyASPNETWebApp.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_AcademyUsers
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Username { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Password { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string UserType { get; set; }
    }
}
