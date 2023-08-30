using CRUD_Employee.Models;
using CRUD_Employee.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Employee.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DBEmployeeContext dbContext;

        public DepartmentService(DBEmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Department>> GetList()
        {
            try
            {
                List<Department> departmentList = new List<Department>();
                departmentList = await dbContext.Departments.ToListAsync();
                return departmentList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
