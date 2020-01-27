using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("vUserCourseMap")]
    public class vUserCourseMap
    {
        [Key]
        public int UserCourseMapId { get; set; }

        public int UserId { get; set; }

        public int CourseId { get; set; }

        [Required]
        [StringLength(240)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(240)]
        public string TeacherName { get; set; }
        [Required]
        [StringLength(240)]
        public string Email { get; set; }
        [Required]
        [StringLength(12)]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(40)]
        public string CourseName { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
    }
}
