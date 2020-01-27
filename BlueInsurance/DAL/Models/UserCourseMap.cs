namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserCourseMap")]
    public partial class UserCourseMap
    {
        [Key]
        public int UserCourseMapId { get; set; }

        public int UserId { get; set; }

        public int CourseId { get; set; }
    }
}
