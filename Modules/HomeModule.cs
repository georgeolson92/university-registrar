using System.Collections.Generic;
using System;
using Nancy;
using University.Objects;

namespace University
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Student> allStudents = Student.GetAll();
        List<Course> allCourses = Course.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("students", allStudents);
        model.Add("courses", allCourses);
        return View["index.cshtml", model];
      };
      Get["/students/new"] = _ => {
        return View["students_form.cshtml"];
      };
      Post["/students/new"] = _ => {
        Student newStudent = new Student(Request.Form["student-name"], Request.Form["student-enrollment"]);
        newStudent.Save();
        List<Student> allStudents = Student.GetAll();
        List<Course> allCourses = Course.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("students", allStudents);
        model.Add("courses", allCourses);
        return View["index.cshtml", model];
      };
      Get["/courses/new"] = _ => {
        return View["courses_form.cshtml"];
      };
      Post["/courses/new"] = _ => {
        Course newCourse = new Course(Request.Form["course-name"], Request.Form["course-number"]);
        newCourse.Save();
        List<Student> allStudents = Student.GetAll();
        List<Course> allCourses = Course.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("students", allStudents);
        model.Add("courses", allCourses);
        return View["index.cshtml", model];
      };
    }
  }
}
