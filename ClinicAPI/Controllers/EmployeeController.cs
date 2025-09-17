using APILayer.DTOs___Validations;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using ClinicAPI.temp.DTOs___Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

            /// <summary>
            /// Add a new employee.
            /// </summary>
            /// <param name="employee">Employee request DTO.</param>
            /// <returns>Created employee ID if successful.</returns>
            [HttpPost("add")]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status409Conflict)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<int>> AddEmployee([FromBody] EmployeeRequestDTO employee)
            {
                var result =await _service.AddNewEmployee(employee);

                return result.Status switch
                {
                    ResultStatus.Success => CreatedAtAction(nameof(GetEmployeeById), new { employeeId = result.Data }, result.Data),
                    ResultStatus.Conflict => Conflict(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }

            /// <summary>
            /// Update an existing employee.
            /// </summary>
            /// <param name="employee">Employee request DTO.</param>
            /// <returns>Status of update.</returns>
            [HttpPut("update")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult> UpdateEmployee([FromBody] EmployeeRequestDTO employee)
            {
                var result =await _service.UpdateEmployee(employee);

                return result.Status switch
                {
                    ResultStatus.Updated => Ok(result.Message),
                    ResultStatus.NotFound => NotFound(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }

            /// <summary>
            /// Delete an employee by ID.
            /// </summary>
            /// <param name="employeeId">Employee ID.</param>
            /// <returns>Status of deletion.</returns>
            [HttpDelete("by{employeeId}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

            /// <summary>
            /// Get employee by ID.
            /// </summary>
            /// <param name="employeeId">Employee ID.</param>
            /// <returns>Employee details.</returns>
            [HttpGet("by{employeeId}")]
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

            /// <summary>
            /// Get all employees.
            /// </summary>
            /// <returns>List of employees.</returns>
            [HttpGet("all/by{clinicname}")]
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
        }
    } 