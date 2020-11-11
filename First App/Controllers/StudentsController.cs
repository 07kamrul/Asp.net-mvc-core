using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using First_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_App.Controllers
{
    public class StudentsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        public ActionResult SaveStudent()
        {

            ViewBag.Department = GetDepartment();
            return View();
        }
        [HttpPost]

        public ActionResult SaveStudent(Student student)
        {
            string msg = "";
            var name = student.Name;
            var regno = student.RegNo;
            var email = student.Email;
            var address = student.Address;
            var dept = student.Department;


            SqlConnection conn = new SqlConnection("Server=DESKTOP-HLUSD4J;Database=FirstApp;Trusted_Connection=True;");
            conn.Open();

            string query = "INSERT INTO STUDENT (name,regno,email,address,department)VALUES('" + name + "','" + regno + "','" + email + "','" + address + "','" + dept+ "')";

            SqlCommand cmd = new SqlCommand(query, conn);

            int rowCount = cmd.ExecuteNonQuery();

            if(rowCount > 0)
            {
                msg = "Save data successfully";
            }
            else
            {
                msg = "Saved failed";

            }
            ViewBag.Department = GetDepartment();
            ViewBag.Message = msg;

            return View();

        }


       /* public ActionResult Index()
        {
            Student student = new Student();
            student.Name = "Kamrul Hasan";
            student.RegNo = "2020";
            student.Email = "kamrul@gmail.com";
            student.Address = "Dhaka";
            student.Department = "CSE";


            ViewBag.Student = student;
            return View();
        }
*/
        public ActionResult GetAll()
        {
         //   ViewBag.Students = Students();

            return View(Students());
        }

        public List<string>GetDepartment()
        {
            return new List<string> { "CSE", "EEE", "ECE" };
        }

        public List<Student> Students()
        {
            return new List<Student>
            {
                new Student{Name="Kamrul", RegNo="2021", Email="kamrulhasan@gmail.com", Address="Mirpur", Department="CSE"},
                new Student{Name="Hasan", RegNo="2021", Email="hasan@gmail.com", Address="Mirpur Dhaka", Department="IT"}
        };
        }

    }
}
