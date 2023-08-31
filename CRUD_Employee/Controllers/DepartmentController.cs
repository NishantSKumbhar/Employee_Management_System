using AutoMapper;
using CRUD_Employee.DTOs;
using CRUD_Employee.Models;
using CRUD_Employee.Services.Contract;
using CRUD_Employee.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDepartmentService departmentService;

        public DepartmentController(IMapper mapper, IDepartmentService departmentService)
        {
            this.mapper = mapper;
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseAPI<List<DepartmentDTO>> responseAPI = new ResponseAPI<List<DepartmentDTO>>();
            try
            {
                List<Department> departments = await departmentService.GetList();
                if(departments.Count > 0)
                {
                    List<DepartmentDTO> dtoList = mapper.Map<List<DepartmentDTO>>(departments);
                    responseAPI = new ResponseAPI<List<DepartmentDTO>>()
                    {
                        Status = true,
                        Msg = "OK",
                        Value = dtoList
                    };

                }
                else
                {
                    responseAPI = new ResponseAPI<List<DepartmentDTO>>()
                    {
                        Status = false,
                        Msg = "NO Data"
             
                    };
                }
                return StatusCode(StatusCodes.Status200OK, responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI = new ResponseAPI<List<DepartmentDTO>>()
                {
                    Status = false,
                    Msg = ex.Message
                    
                };

                return StatusCode(StatusCodes.Status500InternalServerError, responseAPI);
            }
        }
    }
}
