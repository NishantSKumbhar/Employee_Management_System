using CRUD_Employee.Models;

namespace CRUD_Employee.Services.Contract
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetList();
        Task<Employee> Get(int idEmployee);
        Task<Employee> Add(Employee model);
        Task<Employee> Update(Employee model);
        Task<bool> Delete(Employee model);
    }
}
