using BusinessLayer.BusinessLogic;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLayer.DTOsPresentation;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly MedicalRecordServices _service;

        public MedicalRecordController(MedicalRecordServices service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<int>> AddMedicalRecord([FromBody] MedicalRecordRequestDTO record)
        //{
        //    var result =await _service.AddNewMedicalRecord(record);

        //    return result.Status switch
        //    {
        //        ResultStatus.Success => CreatedAtAction(nameof(GetLastRecordByUserId), new { userId = result.Data }, result.Data),
        //        ResultStatus.InternalError => StatusCode(500, result.Message),
        //        ResultStatus.Conflict => Conflict(result.Message),
        //        _ => BadRequest(result.Message)
        //    };
        //}

        [HttpPut("{MedicalRecord:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateMedicalRecord(int MedicalRecord, [FromBody] MedicalRecord record)
        {
            var result =await _service.UpdateMedicalRecord(record);

            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.Conflict=>Conflict(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpDelete("{medicalrecordid:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteMedicalRecord(int medicalrecordid)
        {
            var result =await _service.DeleteMedicalRecord (medicalrecordid);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpGet("{userid:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicalRecord>> GetLastRecordByUserId(int userid)
        {
            var result =await _service.GetLastMedcalRecordForPatientByUserId(userid);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpGet("all/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<MedicalRecord>>> GetAllByUserId(int userId)
        {
            var result =await _service.GetMedicalRecordsForPatientByUserID(userId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.Conflict => Conflict( result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }
        [HttpGet("medical-records/latest/{userid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicalRecordInfoDTO>>GetLatestMedicalRecord(int userid)
        {
            var result = await _service
                .GetLastMedcalRecordForPatientByUserId(userid);

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
