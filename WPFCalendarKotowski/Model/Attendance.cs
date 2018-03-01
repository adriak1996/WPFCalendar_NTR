namespace WPFCalendarKotowski.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attendance")]
    public partial class Attendance
    {
        [Key]
        [Column(Order = 0)]
        public Guid AppointmentID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid PersonID { get; set; }

        public bool Accepted { get; set; }

        public virtual Appointment Appointments { get; set; }

        public virtual Person People { get; set; }
    }
}
