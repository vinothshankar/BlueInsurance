using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("vCourseMaster")]
    public class vCourseMaster
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

        [Required]
        [StringLength(240)]
        public string FirstName { get; set; }
    }
}
