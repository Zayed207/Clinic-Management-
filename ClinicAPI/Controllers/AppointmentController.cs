using BusinessLayer.BusinessLogic;
using BusinessLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Add a new appointment.
        /// </summary>
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int> >AddAppointment([FromBody] AppointmentRequestDTO appointment)
        {
            var result = await _service.AddNewAppointment(appointment);
            return result.Status switch
            {
                ResultStatus.Success => CreatedAtAction(nameof(GetAppointmentsToday), new { id = result.Data }, result.Data),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Update an appointment.
        /// </summary>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult >UpdateAppointment([FromBody] AppointmentRequestDTO appointment)
        {
            var result = await  _service.UpdateAppointment(appointment);
            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Delete an appointment by ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult >DeleteAppointment(int id)
        {
            var result = await _service.DeleteAppointment(id);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Delete appointment by Patient ID.
        /// </summary>
        [HttpDelete("By-patientId/{patientId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult >DeleteAppointmentByPatient(int patientId)
        {
            var result =await _service.DeleteAppointmentByPatientID(patientId);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Get all appointments today.
        /// </summary>
        [HttpGet("today")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Appointment>> >GetAppointmentsToday()
        {
            var result =await _service.GetAllAppointmentsToDay();
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Get all appointments today by Doctor ID.
        /// </summary>
        [HttpGet("today/doctor/{doctorId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Appointment>> >GetAppointmentsTodayByDoctor(int doctorId)
        {
            var result =await _service.GetAllAppointmentsToDayByDoctorID(doctorId);
            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Get all appointments today by Clinic name.
        /// </summary>
        [HttpGet("today/clinic/{clinicName}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Appointment>> >GetAppointmentsTodayByClinic(string clinicName)
        {
            var result =await _service.GetAllAppointmentsToDayByClinicName(clinicName);
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

