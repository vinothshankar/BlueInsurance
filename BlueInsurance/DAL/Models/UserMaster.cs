namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserMaster")]
    public partial class UserMaster
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(240)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(240)]
        public string SurName { get; set; }

        [Required]
        [StringLength(240)]
        public string Email { get; set; }

        [StringLength(8)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [StringLength(240)]
        public string Address1 { get; set; }

        [StringLength(240)]
        public string Address2 { get; set; }

        [StringLength(240)]
        public string Address3 { get; set; }

        [Required]
        [StringLength(240)]
        public string UserType { get; set; }
    }
}
