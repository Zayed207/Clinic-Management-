using BusinessLayer;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsPresentation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Threading.Tasks;

namespace ClinicAPI.Controllers
{
        [Route("api/[controller]")]
        public class EmployeeController : ControllerBase
        {
            readonly EmployeeServices _service;
       

        public EmployeeController(EmployeeServices services)
            {
                _service = services;
            
        }

       
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddEmployee([FromBody] EmployeeRequestDTO employee)
        {
           

            {
                var result = await _service.AddNewEmployee(employee);

                return result.Status switch
                {
                    ResultStatus.Success => CreatedAtAction(nameof(GetEmployeeById), new { employeeId = result.Data }, result.Data),
                    ResultStatus.Conflict => Conflict(result.Message),
                    ResultStatus.NotFound=> NotFound(result.Message),       
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };

            }
        }

          
        [HttpPut("{employeeid:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateEmployee(int employeeid,[FromBody] EmployeeRequestDTO employee)
            {
                var result =await _service.UpdateEmployee(employee, employeeid);

                return result.Status switch
                {
                    ResultStatus.Updated => Ok(result.Message),
                    ResultStatus.NotFound => NotFound(result.Message),
                    ResultStatus.Conflict=>Conflict(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }

         
            [HttpDelete("{employeeId:int}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status409Conflict)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult> DeleteEmployee(int employeeId)
            {
                var result =await _service.DeleteEmployee(employeeId);

                return result.Status switch
                {
                    ResultStatus.Success => Ok(result.Message),
                    ResultStatus.NotFound => NotFound(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }

         
            [HttpGet("{employeeId:int}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<Employee>> GetEmployeeById(int userId)
            {
                var result =await _service.GetEmployeeByUserId(userId);

                return result.Status switch
                {
                    ResultStatus.Success => Ok(result.Data),
                    ResultStatus.NotFound => NotFound(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }

           
            [HttpGet("in/{clinicname}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<List<Employee>>> GetAllEmployeesInClinicByClinicName(string clinicname)
            {
                var result =await _service.GetAllEmployeesInClinicByClinicName(clinicname);

                return result.Status switch
                {
                    ResultStatus.Success => Ok(result.Data),
                    ResultStatus.NotFound => NoContent(),

                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }
        [HttpGet("employees/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmployeeInfoDTO>>  GetEmployeeByUserId(int userId)
        {
            var result = await _service.GetEmployeeByUserId(userId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                _ => StatusCode(
                        StatusCodes.Status500InternalServerError,
                        result.Message)
            };
        }

    }
} 