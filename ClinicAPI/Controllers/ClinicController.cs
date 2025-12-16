using AutoMapper;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsPresentation;
using BusinessLayer.DTOsPresentation.ClinicDTOs;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
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


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddClinic([FromBody] ClinicRequestDTO clinic)
        {
            var result = await _service.AddNewClinic(clinic);
            return result.Status switch
            {
                ResultStatus.Success => Created(nameof(GetClinicById), result.Data),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                ResultStatus.Conflict => Conflict(result.Message),

                _ => BadRequest(result.Message)
            };
        }


        [HttpPut("{cinicid:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateClinic(int clinicid, [FromBody] ClinicRequestDTO clinic)
        {
            var result = await _service.UpdateClinic(clinicid, clinic);
            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.Conflict => Conflict(result.Message),

                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteClinic(int id)
        {
            var result = await _service.DeleteClinic(id);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.Conflict => Conflict(result.Message),

                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClinicInfoDTO>> GetClinicById(int id)
        {
            var result = await _service.GetClinicInfo(id);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.Conflict => Conflict(result.Message),


                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllClinics()
        {
            var result = await _service.GetAllClinics();
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.Conflict => Conflict(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }




    }

}

