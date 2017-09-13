using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddStudent(Student stu)
        {
            if (stu != null)
            {
                using (MusicStoreDataContext dbContext = new MusicStoreDataContext())
                {
                    dbContext.Student.Add(stu);
                    dbContext.SaveChanges();
                    return Json(stu, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Some Error Occured");
            }
        }
        [HttpPost]
        public string UpdateStudent(Student stu)
        {
            if (stu != null)
            {
                using (MusicStoreDataContext dbContext = new MusicStoreDataContext())
                {
                    Student lstStudent = dbContext.Student.Where(x => x.ID == stu.ID).FirstOrDefault();
                    lstStudent.StudentName = stu.StudentName;
                    lstStudent.StudentAddress = stu.StudentAddress;
                    lstStudent.StudentEmail = stu.StudentEmail;
                    dbContext.SaveChanges();
                    return "Student Updated";
                }
            }
            else
            {
                return "Oops! something went wrong.";
            }
        }
        public JsonResult GetStudentList()
        {
            using (MusicStoreDataContext dbContext = new MusicStoreDataContext())
            {
                List<Student> studentList = dbContext.Student.ToList();
                var x= Json(studentList, JsonRequestBehavior.AllowGet);
                return x;
            }
        }
        [HttpPost]
        public string DeleteStudent(int Id)
        {
            if (Id != 0)
            {
                using (MusicStoreDataContext dataContext = new MusicStoreDataContext())
                {
                    // int id = Convert.ToInt32(Id);  
                    var lstStud = dataContext.Student.Where(x => x.ID == Id).FirstOrDefault();
                    dataContext.Student.Remove(lstStud);
                    dataContext.SaveChanges();
                    return "Student has been deleted succhessfully.";
                }
            }
            else
            {
                return " Oops! Error occered.";
            }
        }
    }
}
