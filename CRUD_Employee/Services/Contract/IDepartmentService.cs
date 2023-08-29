using CRUD_Employee.Models;

namespace CRUD_Employee.Services.Contract
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetList();
    }
}
