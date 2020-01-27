namespace EntityLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserType")]
    public partial class UserType
    {
        [Key]
        public int UserTypeId { get; set; }

        [StringLength(16)]
        public string UserTypeName { get; set; }
    }
}
