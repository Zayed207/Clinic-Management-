using BusinessLayer.BusinessLogic;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BusinessLayer.DTOsPresentation.AppoinntmentsDTOs;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentServices _service;

        public AppointmentController(AppointmentServices service)
        {
            _service = service;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateAppointment([FromBody] AppointmentRequestDTO appointment)
        {

            var result = await _service.CreateAppointment(appointment);
            return result.Status switch
            {
                ResultStatus.Success => Created(nameof(GetByID) ,result.Data),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                ResultStatus.Conflict => Conflict(result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateAppointment([FromBody] AppointmentRequestDTO appointment)
        {
            var result = await _service.UpdateAppointment(appointment);
            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.Conflict => Conflict(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            var result = await _service.DeleteAppointment(id);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.Conflict => Conflict(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpDelete("{patientId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAppointmentByPatient(int patientId)
        {
            var result = await _service.DeleteAppointmentByPatientID(patientId);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.Conflict => Conflict(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpGet("today")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Appointment>>> GetAppointmentsToday()
        {
            var result = await _service.GetAllAppointmentsToDay();
            return result.Status switch
            {
                ResultStatus.Success => Ok( result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpGet("today/doctor/{doctorId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<List<Appointment>> >GetAppointmentsTodayByDoctor(int doctorId)
        //{
        //    var result = new List<Appointment>();//_service.GetAllAppointmentsToDayByDoctorID(doctorId);
        //    return await result.Status switch
        //    {
        //        ResultStatus.Success => Ok(result.Data),
        //        ResultStatus.NotFound => NotFound(result.Message),
        //        ResultStatus.InternalError => StatusCode(500, result.Message),
        //        _ => BadRequest(result.Message)
        //    };
        //}


        [HttpGet("today/clinic/{clinicName}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Appointment>>> GetAppointmentsTodayByClinic(string clinicName)
        {
            //var result = await _service.GetAllAppointmentsToDayByClinicName(clinicName);
            //return result.Status switch
            //{
            //    ResultStatus.Success => Ok(result.Data),
            //    ResultStatus.NotFound => NotFound(result.Message),
            //    ResultStatus.InternalError => StatusCode(500, result.Message),
            //    _ => BadRequest(result.Message)
            //};
            return NoContent();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Appointment>>> GetByID(int id)
        {
            var result = await _service.GetAppointmentByID(id);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.ValidationError=> BadRequest(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
            
        }
        [HttpGet("today/doctor/{doctorId:int}")]
        public async Task<ActionResult<IEnumerable<AppointmentCalendarDTO>>> GetTodayAppointmentsByDoctor(int doctorId)
        {
            var result =
                await _service
                    .GetTodayAppointmentsByDoctorID(doctorId);

            switch (result.Status)
            {
                case ResultStatus.Success:
                    return Ok(result.Data); 

                case ResultStatus.NotFound:
                    return NotFound(result.Message);

                case ResultStatus.Conflict:
                    return Conflict(result.Message);

                case ResultStatus.ValidationError:
                    return BadRequest(result.Message);

                default:
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        "Unexpected server error");
            }
        }


    }
}


