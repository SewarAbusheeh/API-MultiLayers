using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;

namespace Tahelef.Core.Repository
{
     public interface IStudentRepository
    {
        List<Student> GetAllStudent();
        void CreateStudent(Student Student);
        void UpdateStudent(Student Student);
        void DeleteStudent(int id);
        Student GetStudentById(int id);
    }
}
