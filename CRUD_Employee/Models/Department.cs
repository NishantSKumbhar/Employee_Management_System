using System;
using System.Collections.Generic;

namespace CRUD_Employee.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int IdDepartment { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
