using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngProject.Models
{
    public class EmployeeContext :DbContext
    {
        public EmployeeContext()
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}