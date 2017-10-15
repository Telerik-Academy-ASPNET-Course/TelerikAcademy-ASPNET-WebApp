namespace TelerikAcademyASPNETWebApp.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDb : DbContext
    {
        public ModelDb()
            : base("name=ModelDb")
        {
        }

        public virtual DbSet<AcademyUsers> AcademyUsers { get; set; }
        public virtual DbSet<AcademyUserTypes> AcademyUserTypes { get; set; }
        public virtual DbSet<VW_AcademyUsers> VW_AcademyUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademyUsers>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<AcademyUsers>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<AcademyUserTypes>()
                .Property(e => e.UserType)
                .IsUnicode(false);

            modelBuilder.Entity<AcademyUserTypes>()
                .HasMany(e => e.AcademyUsers)
                .WithRequired(e => e.AcademyUserTypes)
                .HasForeignKey(e => e.UserType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VW_AcademyUsers>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<VW_AcademyUsers>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<VW_AcademyUsers>()
                .Property(e => e.UserType)
                .IsUnicode(false);
        }
    }
}
