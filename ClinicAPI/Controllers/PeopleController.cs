using APILayer.DTOs___Validations;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsForPresentationLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

            /// <summary>
            /// Add a new person.
            /// </summary>
            [HttpPost("Add")]
            [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
            [ProducesResponseType(StatusCodes.Status409Conflict)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<int>> AddPerson([FromBody] PersonRequestDTO person)
            {
                var result =await _service.AddNewPerson(person);

                return result.Status switch
                {
                    ResultStatus.Success => CreatedAtAction(nameof(GetPersonById), new { personId = result.Data }, result.Data),
                    ResultStatus.Conflict => Conflict(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }

            /// <summary>
            /// Update an existing person.
            /// </summary>
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

            /// <summary>
            /// Delete a person by ID.
            /// </summary>
            [HttpDelete("by{personId}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult> DeletePerson(int personId)
            {
                var result =await _service.DeletePerson(personId);

                return result.Status switch
                {
                    ResultStatus.Success => Ok(result.Message),
                    ResultStatus.NotFound => NotFound(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }

            /// <summary>
            /// Get person by ID.
            /// </summary>
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

            /// <summary>
            /// Get person by UserId.
            /// </summary>
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

            /// <summary>
            /// Get person by Email.
            /// </summary>
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


