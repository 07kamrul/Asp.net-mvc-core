using First_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_App.Gateway;


namespace First_App.Manager
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();

        public List<Student>GetStudents()
        {
            return studentGateway.GetStudents();
        }

        public List<Department>GetDepartments()
        {
            return studentGateway.GetDepartments();
        }
    }
}
