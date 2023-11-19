using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;
using Tahelef.Core.Repository;
using Tahelef.Core.Service;

namespace TahelefCourse.Infra.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
    
        public void CreateStudent(Student Student)
        {
            _studentRepository.CreateStudent(Student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }

        public List<Student> GetAllStudent()
        {
            return    _studentRepository.GetAllStudent();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public void UpdateStudent(Student Student)
        {
            _studentRepository.UpdateStudent(Student);
        }
    }
}
