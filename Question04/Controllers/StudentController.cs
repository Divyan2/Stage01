using LibrariesStage01.DBContext;
using LibrariesStage01.Interface;
using LibrariesStage01.Models;
using LibrariesStage01.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Question04.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _studentRepo;

        public StudentController()
        {
            _studentRepo = new StudentRepo(new StudentDbContext());
        }
        public ActionResult Index()
        {
            var students = _studentRepo.GetAllStudents();
            return View(students);
        }

        public ActionResult Details(long id)
        {
            var student = _studentRepo.GetStudentById(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.AddStudent(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Edit(long id)
        {
            var student = _studentRepo.GetStudentById(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.UpdateStudent(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Delete(long id)
        {
            var student = _studentRepo.GetStudentById(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _studentRepo.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}