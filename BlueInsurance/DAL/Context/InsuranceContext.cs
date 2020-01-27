using System;
using System.Data.Entity;
using DAL.Models;

namespace DAL.Context
{
    public partial class InsuranceContext : DbContext
    {
        public InsuranceContext()
            : base("InsuranceContext")
        {
        }

        public virtual DbSet<CourseMaster> CourseMasters { get; set; }
        public virtual DbSet<UserCourseMap> UserCourseMaps { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
        public virtual DbSet<vCourseMaster> vCourseMaster { get; set; }
        public virtual DbSet<vUserCourseMap> vUserCourseMap { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
