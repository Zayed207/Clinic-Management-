using BusinessLayer.BusinessLogic;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpPost("Add")]
        public async Task<ActionResult<int>> AddMedicalRecord([FromBody] MedicalRecord record)
        {
            var result =await _service.AddNewMedicalRecord(record);

            return result.Status switch
            {
                ResultStatus.Success => CreatedAtAction(nameof(GetLastRecordByUserId), new { userId = result.Data }, result.Data),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateMedicalRecord([FromBody] MedicalRecord record)
        {
            var result =await _service.UpdateMedicalRecord(record);

            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpDelete("by{medicalrecordid}")]
        public async Task<ActionResult> DeleteMedicalRecord(int mrnId)
        {
            var result =await _service.DeleteMedicalRecord (mrnId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpGet("Last/{userId}")]
        public async Task<ActionResult<MedicalRecord>> GetLastRecordByUserId(int userId)
        {
            var result =await _service.GetLastMedcalRecordForPatientByUserId(userId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpGet("all/by{userId}")]
        public async Task<ActionResult<List<MedicalRecord>>> GetAllByUserId(int userId)
        {
            var result =await _service.GetMedicalRecordsForPatientByUserID(userId);

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
