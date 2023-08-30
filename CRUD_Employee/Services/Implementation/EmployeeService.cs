using CRUD_Employee.Models;
using CRUD_Employee.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Employee.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DBEmployeeContext dBContext;

        public EmployeeService(DBEmployeeContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<Employee>> GetList()
        {
            try
            {
                List<Employee> employeeList = new List<Employee>();
                employeeList = await this.dBContext.Employees.Include(dept => dept.IdDepartmentNavigation).ToListAsync();
                return employeeList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Employee> Get(int idEmployee)
        {
            try
            {
                Employee? employeeFound = new Employee();
                employeeFound = await this.dBContext.Employees.Include(dept => dept.IdDepartmentNavigation)
                    .Where(x => x.IdDepartment == idEmployee)
                    .FirstOrDefaultAsync();
                return employeeFound;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Employee> Add(Employee model)
        {
            try
            {
                await this.dBContext.Employees.AddAsync(model);
                await this.dBContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Employee> Update(Employee model)
        {
            try
            {
                this.dBContext.Employees.Update(model);
                await this.dBContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(Employee model)
        {
            try
            {
                this.dBContext.Employees.Remove(model);
                await this.dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       

        

        
    }
}
