using LibrariesStage01.DBContext;
using LibrariesStage01.Interface;
using LibrariesStage01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesStage01.Repository
{
    public class StudentRepo : IStudent
    {
        private readonly StudentDbContext _dbContext;
        public StudentRepo()
        {
            _dbContext = new StudentDbContext();
        }

        public StudentRepo(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public void DeleteStudent(long id)
        {
            var DelStudent = _dbContext.Students.Find(id);

            if(DelStudent != null)
            {
                DelStudent.IsActive = false;
                _dbContext.SaveChanges();
            }
        }

        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.Where(x=>x.IsActive).ToList();
        }

        public Student GetStudentById(long id)
        {
            return _dbContext.Students.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = _dbContext.Students.Find(student.Id);

            if (existingStudent != null)
            {
                existingStudent.Fname = student.Fname;
                existingStudent.Lname = student.Lname;
                existingStudent.Age = student.Age;
                existingStudent.Address = student.Address; //change for question 5 

                _dbContext.SaveChanges();
            }
        }
    }
}
