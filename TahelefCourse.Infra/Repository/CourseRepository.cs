using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;
using Tahelef.Core.Repository;
using TahelefCourse.Core.Common;
using TahelefCourse.Infra.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TahelefCourse.Infra.Repository
{
    public class CourseRepository : ICourseRepository
    {

        //Instance == inject to IDbContext

        private readonly IDbContext dbContext;

        public CourseRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public void CreateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("COURSENAME", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CATID", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Course_Package.CREATECOURSE", p, commandType: CommandType.StoredProcedure);
        }

      

        public void DeleteCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Course_Package.DeleteCourse", p, commandType: CommandType.StoredProcedure);
        }

        ////Instance == inject to IDbContext

        //private readonly IDbContext dbContext;

        //public CourseRepoistory(IDbContext _dbContext)
        //{
        //    this.dbContext = _dbContext;
        //}

        //// get all courses == list<course> == retrive data from database 
        public List<Course> GetAllCourses()
        {
            IEnumerable<Course> result = dbContext.Connection.Query<Course>("Course_Package.GetAllCourses", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }

        public Course GetByCourseId(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Course> result = dbContext.Connection.Query<Course>("Course_Package.GetCourseById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

     
      public void UpdateCourse(Course course)
       {
            var p = new DynamicParameters();
            p.Add("ID", course.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CNAME", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CATID", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Course_Package.UPDATECOURSE", p, commandType: CommandType.StoredProcedure);
        }
    }
}
