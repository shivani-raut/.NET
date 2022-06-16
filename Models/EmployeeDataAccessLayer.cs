using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AngProject.Models
{
    public class EmployeeDataAccessLayer
    {
        string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = AngProject.Models.EmployeeContext; Integrated Security = true";
        public IEnumerable<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.City = rdr["City"].ToString();
                        employees.Add(employee);
                    }
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
            return employees;
        }
        public int AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        public int UpdateEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee emp = new Employee();
                using(SqlConnection con = new SqlConnection(cs))
                {
                    string query = "Select * from [dbo].[Employees] where EmployeeId = " + id;
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        emp.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        emp.Name = rdr["Name"].ToString();
                        emp.Gender = rdr["Gender"].ToString();
                        emp.Department = rdr["Department"].ToString();
                        emp.City = rdr["City"].ToString();
                    }
                }
                return emp;
            }
            catch
            {
                throw;
            }
        }
        public int DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}