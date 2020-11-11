using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using First_App.Models;

namespace First_App.Gateway
{
    public class StudentGateway
    {

        public List<Student> GetStudents()
        {
            SqlConnection conn = new SqlConnection("Server=DESKTOP-HLUSD4J;Database=FirstApp;Trusted_Connection=True;");
            string query = "SELECT * FROM vStudentInfo";

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> students = new List<Student>();

            while (reader.Read())
            {
                Student student = new Student();
                student.Name = reader["Name"].ToString();
                student.RegNo = reader["RegNo"].ToString();
                student.Email = reader["Email"].ToString();
                student.Address = reader["Address"].ToString();
                student.Department = reader["DepartmentName"].ToString();
                students.Add(student);

            }
            conn.Close();
            return students;
        }

        public List<Department> GetDepartments()
        {
            SqlConnection conn = new SqlConnection("Server=DESKTOP-HLUSD4J;Database=FirstApp;Trusted_Connection=True;");
            string query = "SELECT * FROM Department";

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Department> departments = new List<Department>();

            while(reader.Read())
            {
                Department department = new Department();
                department.Id = (int)reader["Id"];
                department.ShortName = reader["ShortName"].ToString();
                departments.Add(department);
            }
            conn.Close();
            return departments;

        }
    }
}
