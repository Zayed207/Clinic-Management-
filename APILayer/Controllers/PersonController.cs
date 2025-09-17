using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using BusinessLayer;

using BusinessLayer;
namespace APILayer.Controllers
{
    [Route("api/People")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task< ActionResult<List<clsPerson>>>    GetAllPersons()
        {
          var PeopleList= await  clsPerson.GetAllPersons();

            if ( PeopleList == null||PeopleList.Count == 0) return NoContent();
            

            else if (PeopleList.Count > 0) return Ok(PeopleList);

            else 
                
                return BadRequest();


            
        }





    }
}
