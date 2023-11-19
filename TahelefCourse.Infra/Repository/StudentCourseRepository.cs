using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;
using Tahelef.Core.Repository;
using TahelefCourse.Core.Common;

namespace TahelefCourse.Infra.Repository
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly IDbContext dBContext;
        public StudentCourseRepository(IDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void CreateStudentCourse(Stdcourse studentCourse)
        {
            var p = new DynamicParameters();
            p.Add("stdidid", studentCourse.Stdid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("courseid", studentCourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("markof", studentCourse.Marksofstd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("dateof_register", studentCourse.Dateofregister, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("stdcourse_Package.CreateStdCourse", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteStudentCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("SCID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("stdcourse_Package.DeleteStdCourse", p, commandType: CommandType.StoredProcedure);
        }

        public List<Stdcourse> GetAllStudentCourse()
        {
            IEnumerable<Stdcourse> result = dBContext.Connection.Query<Stdcourse>("stdcourse_Package.GetAllStdCourse", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Stdcourse GetStudentCourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("SCID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Stdcourse> result = dBContext.Connection.Query<Stdcourse>("stdcourse_Package.GetStdCourseById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateStudentCourse(Stdcourse studentCourse)
        {
            var p = new DynamicParameters();
            p.Add("SCid", studentCourse.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("stdidid", studentCourse.Stdid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("courseid", studentCourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("markof", studentCourse.Marksofstd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("dateof_register", studentCourse.Dateofregister, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("stdcourse_Package.UpdateStdCourse", p, commandType: CommandType.StoredProcedure);
        }
    }
}
