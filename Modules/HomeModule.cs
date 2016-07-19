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
      Get["/students/all/delete/"] = _ => {
        List<Student> allStudents = Student.GetAll();
        return View["delete_allstudents.cshtml", allStudents];
      };
      Get["/courses/all/delete/"] = _ => {
        List<Course> allCourses = Course.GetAll();
        return View["delete_allcourses.cshtml", allCourses];
      };
      Delete["/students/all/delete/"] = _ => {
        Student.DeleteAll();
        List<Student> allStudents = Student.GetAll();
        List<Course> allCourses = Course.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("students", allStudents);
        model.Add("courses", allCourses);
        return View["index.cshtml", model];
      };
      Delete["/courses/all/delete/"] = _ => {
        Course.DeleteAll();
        List<Student> allStudents = Student.GetAll();
        List<Course> allCourses = Course.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("students", allStudents);
        model.Add("courses", allCourses);
        return View["index.cshtml", model];
      };
      Get["/students/{id}/delete/"] = parameters => {
        int studentId = parameters.id;
        Student foundStudent = Student.Find(studentId);
        return View["delete_student.cshtml", foundStudent];
      };
      Get["/courses/{id}/delete/"] = parameters => {
        int courseId = parameters.id;
        Course foundCourse = Course.Find(courseId);
        return View["delete_course.cshtml", foundCourse];
      };
      Delete["/students/{id}/delete/"] = parameters => {
        int studentId = parameters.id;
        Student foundStudent = Student.Find(studentId);
        foundStudent.Delete();
        List<Student> allStudents = Student.GetAll();
        List<Course> allCourses = Course.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("students", allStudents);
        model.Add("courses", allCourses);
        return View["index.cshtml", model];
      };
      Delete["/courses/{id}/delete/"] = parameters => {
        int courseId = parameters.id;
        Course foundCourse = Course.Find(courseId);
        foundCourse.Delete();
        List<Student> allStudents = Student.GetAll();
        List<Course> allCourses = Course.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("students", allStudents);
        model.Add("courses", allCourses);
        return View["index.cshtml", model];
      };
      Get["/students/{id}"] = parameters => {
        int studentId = parameters.id;
        Student foundStudent = Student.Find(studentId);
        List<Course> foundCourses = foundStudent.GetCourses();
        List<Course> allCourses = Course.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("student", foundStudent);
        model.Add("courses", foundCourses);
        model.Add("all-courses", allCourses);
        return View["student.cshtml", model];
      };
      Get["/courses/{id}"] = parameters => {
        int courseId = parameters.id;
        Course foundCourse = Course.Find(courseId);
        List<Student> foundStudents = foundCourse.GetStudents();
        List<Student> allStudents = Student.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("course", foundCourse);
        model.Add("students", foundStudents);
        model.Add("all-students", allStudents);
        return View["course.cshtml", model];
      };
      Post["students/add/course"] = _ => {
        int studentSearch = Request.Form["student-id"];
        int courseSearch = Request.Form["course-name"];
        Student foundStudent = Student.Find(studentSearch);
        Course newCourse = Course.Find(courseSearch);
        foundStudent.AddCourse(newCourse);
        List<Course> foundCourses = foundStudent.GetCourses();
        List<Course> allCourses = Course.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("student", foundStudent);
        model.Add("courses", foundCourses);
        model.Add("all-courses", allCourses);
        return View["student.cshtml", model];
      };
      Post["courses/add/student"] = _ => {
        int studentSearch = Request.Form["student-name"];
        int courseSearch = Request.Form["course-id"];
        Course foundCourse = Course.Find(courseSearch);
        Student newStudent = Student.Find(studentSearch);
        foundCourse.AddStudent(newStudent);
        List<Student> foundStudents = foundCourse.GetStudents();
        List<Student> allStudents = Student.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("course", foundCourse);
        model.Add("students", foundStudents);
        model.Add("all-students", allStudents);
        return View["course.cshtml", model];
      };
      Post["students/{id}/withdraw"] = parameters => {
        int studentSearch = parameters.id;
        int courseSearch = Request.Form["course-name"];
        Student foundStudent = Student.Find(studentSearch);
        Course newCourse = Course.Find(courseSearch);
        foundStudent.AddCourse(newCourse);
        List<Course> foundCourses = foundStudent.GetCourses();
        List<Course> allCourses = Course.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("student", foundStudent);
        model.Add("courses", foundCourses);
        model.Add("all-courses", allCourses);
        return View["student.cshtml", model];
      };
    }
  }
}
