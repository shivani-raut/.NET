using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
using AngProject.Models;

namespace AngProject.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeeDataAccessLayer employees = new EmployeeDataAccessLayer();

        [HttpGet]
        [Route("api/Employees/Index")]
        public IEnumerable<Employee> Index()
        {
            return employees.getAllEmployees();
        }
        [HttpPost]
        [Route("api/Employees/Create")]
        public int Create([FromBody] Employee employee)
        {
            return employees.AddEmployee(employee);
        }
        [HttpGet]
        [Route("api/Employees/Details/{id}")]
        public Employee Detials(int id)
        {
            return employees.GetEmployeeData(id);
        }

        [HttpPut]
        [Route("api/Employees/Edit")]
        public int Edit([FromBody]Employee employee)
        {
            return employees.UpdateEmployee(employee);
        }
        [HttpDelete]
        [Route("api/Employees/Delete/{id}")]
        public int Delete(int id)
        {
            return employees.DeleteEmployee(id);
        }
    }
}
