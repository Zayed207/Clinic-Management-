using BusinessLayer;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsPresentation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Threading.Tasks;

namespace ClinicAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonServices _service;

        public PersonController(PersonServices service)
        {
            _service = service;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddPerson([FromBody] PersonRequestDTO person)
        {



            var result = await _service.AddNewPerson(person);

            return result.Status switch
            {
                ResultStatus.Success => CreatedAtAction(nameof(GetPersonById), new { personId = result.Data }, result.Data),
                ResultStatus.Conflict => Conflict(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpPut("{perosnid:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePerson(int perosnid, [FromBody] PersonRequestDTO person)
        {
            var result = await _service.UpdatePerson(person);

            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpDelete("{personid:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletePersonByPersonID(int personid)
        {
            var result = await _service.DeletePersonByID(personid);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpGet("{personid:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Person))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> GetPersonById(int personid)
        {
            var result = await _service.GetPersonByID(personid);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }





        //[HttpGet("by_{Email}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Person))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<Person>> GetPersonByEmail( string email)
        //{
        //    var result =await _service.GetPersonByEmail(email);

        //    return result.Status switch
        //    {
        //        ResultStatus.Success => Ok(result.Data),
        //        ResultStatus.NotFound => NotFound(result.Message),
        //        ResultStatus.InternalError => StatusCode(500, result.Message),
        //        _ => BadRequest(result.Message)
        //    };
        //}

    }
}


