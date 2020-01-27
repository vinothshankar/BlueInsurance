using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceService.Service
{
    public class UserCourseMapService: BaseService<UserCourseMap,vUserCourseMap>
    {
        public override int CreateorUpdate(UserCourseMap entity)
        {
            try
            {
                int sameCourse = _context.UserCourseMaps
                    .Where(a => a.CourseId == entity.CourseId 
                    && a.UserId == entity.UserId).ToList().Count;
                int maxCourse= _context.UserCourseMaps
                    .Where(a => a.UserId == entity.UserId).ToList().Count;
                int maxseats = _context.CourseMasters
                    .Where(a => a.CourseId == entity.CourseId)
                    .Select(b => b.MaxSeats).FirstOrDefault();
                int noOfSeatsFilled = _context.UserCourseMaps
                    .Where(a => a.CourseId == entity.CourseId).ToList().Count;

                if (sameCourse > 0 || maxCourse>=5 || noOfSeatsFilled >= maxseats)
                {
                    throw new Exception("Course already registered or Maximum number of course reached or Seats filled");
                }
                else
                {
                    return base.CreateorUpdate(entity);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<vUserCourseMap> getUserCourseMap(int id)
        {
            List<vUserCourseMap> vUserCourseMaps = new List<vUserCourseMap>();
            try
            {
                vUserCourseMaps = _context.vUserCourseMap.Where(a => a.UserId == id).ToList();
            }
            catch
            {
                throw;
            }
            return vUserCourseMaps;
        }
    }
}
