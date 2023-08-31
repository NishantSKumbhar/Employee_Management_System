using AutoMapper;
using CRUD_Employee.DTOs;
using CRUD_Employee.Models;
using CRUD_Employee.Services.Contract;
using CRUD_Employee.Services.Implementation;
using CRUD_Employee.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeeController(EmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseAPI<List<EmployeeDTO>> responseAPI = new ResponseAPI<List<EmployeeDTO>>();
            try
            {
                List<Employee> employeeList = await employeeService.GetList();
                if (employeeList.Count > 0)
                {
                    List<EmployeeDTO> dtoList = mapper.Map<List<EmployeeDTO>>(employeeList);
                    responseAPI = new ResponseAPI<List<EmployeeDTO>>()
                    {
                        Status = true,
                        Msg = "OK",
                        Value = dtoList
                    };

                }
                else
                {
                    responseAPI = new ResponseAPI<List<EmployeeDTO>>()
                    {
                        Status = false,
                        Msg = "NO Data"

                    };
                }
                return StatusCode(StatusCodes.Status200OK, responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI = new ResponseAPI<List<EmployeeDTO>>()
                {
                    Status = false,
                    Msg = ex.Message

                };

                return StatusCode(StatusCodes.Status500InternalServerError, responseAPI);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDTO employeeDTO)
        {
            ResponseAPI<EmployeeDTO> responseAPI = new ResponseAPI<EmployeeDTO>();
            try
            {
                Employee model= mapper.Map<Employee>(employeeDTO);
                Employee employeeCreated = await employeeService.Add(model);

                if (employeeCreated.IdEmployee != 0)
                {
                    EmployeeDTO dto = mapper.Map<EmployeeDTO>(employeeCreated);
                    responseAPI = new ResponseAPI<EmployeeDTO>()
                    {
                        Status = true,
                        Msg = "OK",
                        Value = dto
                    };

                }
                else
                {
                    
                    responseAPI = new ResponseAPI<EmployeeDTO>()
                    {
                        Status = false,
                        Msg = "OK",
                        
                    };
                }
                return StatusCode(StatusCodes.Status200OK, responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI = new ResponseAPI<EmployeeDTO>()
                {
                    Status = false,
                    Msg = ex.Message

                };

                return StatusCode(StatusCodes.Status500InternalServerError, responseAPI);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeDTO employeeDTO)
        {
            ResponseAPI<EmployeeDTO> responseAPI = new ResponseAPI<EmployeeDTO>();
            try
            {
                Employee model = mapper.Map<Employee>(employeeDTO);
                Employee employeeEdited = await employeeService.Update(model);

                
                    EmployeeDTO dto = mapper.Map<EmployeeDTO>(employeeEdited);
                    responseAPI = new ResponseAPI<EmployeeDTO>()
                    {
                        Status = true,
                        Msg = "OK",
                        Value = dto
                    };

               
                return StatusCode(StatusCodes.Status200OK, responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI = new ResponseAPI<EmployeeDTO>()
                {
                    Status = false,
                    Msg = ex.Message

                };

                return StatusCode(StatusCodes.Status500InternalServerError, responseAPI);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseAPI<bool> responseAPI = new ResponseAPI<bool>();
            try
            {
                //Employee model = mapper.Map<Employee>(employeeDTO);
                Employee employeeFound = await employeeService.Get(id);
                bool deleted = await employeeService.Delete(employeeFound);

                if (deleted)
                {
                    responseAPI = new ResponseAPI<bool>()
                    {
                        Status = true,
                        Msg = "OK",
                        
                    };
                }
                else
                {
                    responseAPI = new ResponseAPI<bool>()
                    {
                        Status = false,
                        Msg = "No Deleted",
                        
                    };
                }
             
                return StatusCode(StatusCodes.Status200OK, responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI = new ResponseAPI<bool>()
                {
                    Status = false,
                    Msg = ex.Message

                };

                return StatusCode(StatusCodes.Status500InternalServerError, responseAPI);
            }
        }
    }
}
