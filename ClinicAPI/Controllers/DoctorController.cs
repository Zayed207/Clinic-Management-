using BusinessLayer;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsForPresentationLayer;
using ClinicAPI.temp.DTOs___Validations;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Buffers;
using System.Numerics;
using System.Threading.Tasks;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        readonly DoctorServices _service;
       
        public DoctorController(DoctorServices services)
        {
            _service = services;
           
        }



        
        [HttpPost("add")]
        public async Task<ActionResult<int>> AddNewDoctor( [FromBody] DoctorRequestDTO doctor )
        {
            if (doctor.DoctorTypeID<= 0)
            {
                var creationUrl = Url.Action("AddEmployee", "Employee", null,Request.Scheme);


                return BadRequest(new
                {
                    Message = "Employeeid is missing. Please create a Employee .",
                    CreateTypeUrl = creationUrl
                });
            }


            {
                var result = await _service.AddNewDoctor(doctor);

                return result.Status switch
                {
                    ResultStatus.Success => CreatedAtAction(nameof(GetDoctorById), new { employeeId = result.Data }, result.Data),
                    ResultStatus.Conflict => Conflict(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };

            }
        }

        
        [HttpPut("update")]
        public async Task<ActionResult> UpdateDoctor([FromBody] DoctorRequestDTO doctor)
        {
            var result =await _service.UpdateDoctor(doctor);

            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

     
        [HttpDelete("{userID}")]
        public async Task<ActionResult> DeleteDoctor(int userid)
        {
            var result =await _service.DeleteDoctor(userid);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

       
        [HttpGet("by{employeeId}")]
        public async Task<ActionResult<Doctor>> GetDoctorById(int employeeId)
        {
            var result =await _service.GetDoctorById(employeeId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }
    

      
         [HttpGet("by{userId}")]
        public async Task<ActionResult<Doctor>> GetDoctorByUserId(int userId)
        {
            var result =await _service.GetDoctorByUserId(userId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

       
        [HttpGet("by{clinicId}")]
        public async Task<ActionResult<Doctor>> GetDoctorByClinicId(int clinicId)
        {
            var result =await _service.GetDoctorByClinicId(clinicId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

       
        [HttpGet("all/{clinicId}")]

        [Authorize]
        public async Task<ActionResult<List<Doctor>>> GetAllDoctorsInClinic(int clinicId)
        {
            var result =await _service.GetAllDoctorsInClinc(clinicId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        
        [HttpGet("all/by{clinicName}")]
        public async Task<ActionResult<List<Doctor>>> GetAllDoctorsInClinic(string clinicName)
        {
            var result =await _service.GetAllDoctorsInClinc(clinicName);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }
    }
}   

