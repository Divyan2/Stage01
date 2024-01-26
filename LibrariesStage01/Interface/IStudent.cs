using LibrariesStage01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesStage01.Interface
{
    public interface IStudent
    {
        Student GetStudentById(long id);
        List<Student> GetAllStudents();
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(long id);
    }
}
