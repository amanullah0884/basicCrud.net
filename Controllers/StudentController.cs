using BascCrud.Models;
using BasicCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BascCrud.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public IActionResult StudentCreate(Student student)
        {
            //var studentList = new List<Student>();
            //if (HttpContext.Session.GetString("Student") is not null)
            //{
            //    studentList = JsonConvert.DeserializeObject<List<Student>>(HttpContext.Session.GetString("Student").ToString());
            //}
            //studentList.Add(student);
            //string serializedStudent = JsonConvert.SerializeObject(studentList);
            //HttpContext.Session.SetString("Student", serializedStudent);

            var studentDetails = _studentDbContext.Students.FirstOrDefault(s=>s.Id==student.Id);
            if(studentDetails==null)
            {
                _studentDbContext.Add(student);
                _studentDbContext.SaveChanges();
            }
            return View();

        }
        public IActionResult StudentList()
        {
            //var studentList = JsonConvert.DeserializeObject<List<Student>>(HttpContext.Session.GetString("Student").ToString());
            var studentList = _studentDbContext.Students.ToList();
            return View(studentList);

        }

    }
}
