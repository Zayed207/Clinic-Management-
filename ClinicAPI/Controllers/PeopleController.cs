using APILayer.DTOs___Validations;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsForPresentationLayer;
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

     
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddPerson([FromBody] PersonRequestDTO person)
        {
           
                var creationUrl = Url.Action("AddUser", "User", null, Request.Scheme);


                return BadRequest(new
                {
                    Message = "Userid is missing. Please create a User.",
                    CreateTypeUrl = creationUrl
                });
            

            var result = await _service.AddNewPerson(person);

            return result.Status switch
            {
                ResultStatus.Success => CreatedAtAction(nameof(GetPersonById), new { personId = result.Data }, result.Data),
                ResultStatus.Conflict => Conflict(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

      
        [HttpPut("Update")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult> UpdatePerson([FromBody] PersonRequestDTO person)
            {
                var result =await _service.UpdatePerson(person);

                return result.Status switch
                {
                    ResultStatus.Updated => Ok(result.Message),
                    ResultStatus.NotFound => NotFound(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }

        
            [HttpDelete("by{personId}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult> DeletePersonByPersonID(int personId)
            {
                var result =await _service.DeletePersonByID(personId);

                return result.Status switch
                {
                    ResultStatus.Success => Ok(result.Message),
                    ResultStatus.NotFound => NotFound(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }

          
            [HttpGet("by{personId}")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Person))]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<Person>> GetPersonById(int personId)
            {
                var result =await _service.GetPersonById(personId);

                return result.Status switch
                {
                    ResultStatus.Success => Ok(result.Data),
                    ResultStatus.NotFound => NotFound(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }

           
            [HttpGet("by-{userId}")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Person))]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<Person>> GetPersonByUserId(int userId)
            {
                var result =await _service.GetPersonByUserId(userId);

                return result.Status switch
                {
                    ResultStatus.Success => Ok(result.Data),
                    ResultStatus.NotFound => NotFound(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }

   
            [HttpGet("by_{Email}")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Person))]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<Person>> GetPersonByEmail( string email)
            {
                var result =await _service.GetPersonByEmail(email);

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


