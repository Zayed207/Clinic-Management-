using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly clsPayPal _payPalService;

        public PaymentsController(clsPayPal payPalService)
        {
            _payPalService = payPalService;
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetToken()
        {
            var token = await _payPalService.GetAccessTokenAsync();
            return Ok(new { access_token = token });
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreatePayment([FromBody] decimal amount)
        {
            var approvalUrl = await _payPalService.CreatePaymentAsync(amount);
            return Ok(new { url = approvalUrl });
        }


    }
}
