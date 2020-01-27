namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseMaster")]
    public partial class CourseMaster
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(12)]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(40)]
        public string CourseName { get; set; }

        public int TeacherId { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int MaxSeats { get; set; }
    }
}
