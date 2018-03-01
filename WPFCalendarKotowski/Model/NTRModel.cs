namespace WPFCalendarKotowski.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Validation;

    public partial class NTRModel : DbContext
    {
        public NTRModel()
            : base("name=NTRModel")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasMany(e => e.Attendances)
                .WithRequired(e => e.Appointments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Attendances)
                .WithRequired(e => e.People)
                .WillCascadeOnDelete(false);
        }
    }
}
