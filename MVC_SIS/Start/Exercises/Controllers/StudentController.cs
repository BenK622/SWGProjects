using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult EditStudent(int studentId)
        {


            var student = StudentRepository.Get(studentId);

            StudentVM studentVM = new StudentVM() { Student = student };

            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());

            return View(studentVM);

        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM model)
        {
            model.Student.Courses = new List<Course>();

            foreach (var id in model.SelectedCourseIds)
                model.Student.Courses.Add(CourseRepository.Get(id));

            model.Student.Major = MajorRepository.Get(model.Student.Major.MajorId);

            var student = model.Student;

            StudentRepository.Edit(student);

            StudentRepository.SaveAddress(student.StudentId, student.Address);

            return RedirectToAction("List");

        }

        [HttpGet]
        public ActionResult DeleteStudent(int StudentId)
        {
            var student = StudentRepository.Get(StudentId);

            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            StudentRepository.Delete(student.StudentId);

            return RedirectToAction("List");
        }

    }
}