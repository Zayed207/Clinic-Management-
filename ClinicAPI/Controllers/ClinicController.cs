using AutoMapper;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsForPresentationLayer;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly ClinicServices _service;

        public ClinicController(ClinicServices service)
        {
            _service = service;
        }

        /// <summary>
        /// Add a new clinic.
        /// </summary>
        [HttpPost("Add")]
        public async Task<ActionResult<int>> AddNewClinic([FromBody] ClinicRequestDTO clinic)
        {
            var result =await _service.AddNewClinic(clinic);
            return result.Status switch
            {
                ResultStatus.Success => CreatedAtAction(nameof(GetClinicById), new { id = result.Data }, result.Data),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Update a clinic.
        /// </summary>
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateClinic([FromBody] ClinicRequestDTO clinic)
        {
            var result =await _service.UpdateClinic(clinic);
            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Delete a clinic by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClinic(int id)
        {
            var result =await _service.DeleteClinic(id);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Get clinic by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Clinic>> GetClinicById(int id)
        {
            var result =await _service.GetClinicById(id);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Get all clinics.
        /// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<List<Clinic>>> GetAllClinics()
        {
            var result =await _service.GetAllClinics();
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

