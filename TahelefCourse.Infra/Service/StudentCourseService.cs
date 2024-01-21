using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.DTO;
using Tahelef.Core.Models;
using Tahelef.Core.Repository;
using Tahelef.Core.Service;
using TahelefCourse.Infra.Repository;

namespace TahelefCourse.Infra.Service
{
    public  class StudentCourseService : IStudentCourseService
    {
        private readonly IStudentCourseRepository _StudentCourseRepository;
        public StudentCourseService(IStudentCourseRepository StudentCourseRepository)
        {
            _StudentCourseRepository = StudentCourseRepository;
        }

        public void CreateStudentCourse(Stdcourse StudentCourse)
        {
            _StudentCourseRepository.CreateStudentCourse(StudentCourse);
        }

        public void DeleteStudentCourse(int id)
        {
            _StudentCourseRepository.DeleteStudentCourse(id);
        }

        public List<Stdcourse> GetAllStudentCourse()
        {
            return _StudentCourseRepository.GetAllStudentCourse();
        }

        public Stdcourse GetStudentCourseById(int id)
        {
            return _StudentCourseRepository.GetStudentCourseById(id);
        }

        public void UpdateStudentCourse(Stdcourse StudentCourse)
        {
            _StudentCourseRepository.UpdateStudentCourse(StudentCourse);
        }
        public List<Search> SearcheStudenCourse(Search search)
        {
            return _StudentCourseRepository.SearcheStudenCourse(search);
        }
        public List<TotalStudents> TotalStudentInEachCourse()
        {
            return _StudentCourseRepository.TotalStudentInEachCourse();
        }
    }
}
