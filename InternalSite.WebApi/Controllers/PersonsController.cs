using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Person.Commands.CreatePerson;
using InternalSite.Application.Person.Commands.DeletePerson;
using InternalSite.Application.Person.Commands.UpdatePerson;
using InternalSite.Application.Person.Queries.Common;
using InternalSite.Application.Person.Queries.GetListPersonQuery;
using InternalSite.Application.Person.Queries.GetPersonQuery;
using InternalSite.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternalSite.WebApi.Controllers
{
    /// <summary>
    /// Контроллер сотрудников
    /// </summary>
    [ApiController]
    public class PersonsController : BaseController
    {
        /// <summary>
        /// Метод создает нового сотрудника с набором навыков
        /// </summary>
        /// <param name="createdPersonDto"></param>
        /// <returns></returns>
        [HttpPost("Person")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> СreatePerson(CreatedPersonDto createdPersonDto)
        {
            try
            {
                var сreatedSkillsOfPerson = new List<CreatedSkillOfPerson>();

                foreach (var dto in createdPersonDto.CreatedSkillsOfPersonDto)
                {
                    var newCreatedSkillsOfPerson = new CreatedSkillOfPerson
                    {
                        Level = dto.Level,
                        SkillId = dto.SkillId,
                    };

                    сreatedSkillsOfPerson.Add(newCreatedSkillsOfPerson);
                }

                var command = new CreatePersonCommand
                {
                    Name = createdPersonDto.Name,
                    Surname = createdPersonDto.Surname,
                    Patronymic = createdPersonDto.Patronymic,
                    Birthday = createdPersonDto.Birthday,
                    PhoneNumber = createdPersonDto.PhoneNumber,
                    CategoryId = createdPersonDto.CategoryId,
                    PositionId = createdPersonDto.PositionId,
                    CreatedSkillsOfPerson = сreatedSkillsOfPerson
                };

                var newPerson = await Mediator.Send(command);

                return Created("", newPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Метод изменяет существуещего сотрудника и его навыки
        /// </summary>
        /// <param name="updatePersonDto"></param>
        /// <returns></returns>
        [HttpPut("Person")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePerson(UpdatePersonDto updatePersonDto)
        {
            try
            {
                var updateSkillsOfPerson = new List<UpdateSkillOfPerson>();

                foreach (var skillOfPerson in updatePersonDto.UpdateSkillsOfPersonDto)
                {
                    var updateSkiiOfPerson = new UpdateSkillOfPerson
                    {
                        Id = skillOfPerson.Id,
                        SkillId = skillOfPerson.SkillId,
                        Level = skillOfPerson.Level,
                    };

                    updateSkillsOfPerson.Add(updateSkiiOfPerson);
                }

                var command = new UpdatePersonCommand
                {
                    Id = updatePersonDto.Id,
                    Name = updatePersonDto.Name,
                    Surname = updatePersonDto.Surname,
                    Patronymic = updatePersonDto.Patronymic,
                    Birthday = updatePersonDto.Birthday,
                    PhoneNumber = updatePersonDto.PhoneNumber,
                    CategoryId = updatePersonDto.CategoryId,
                    PositionId = updatePersonDto.PositionId,
                    UpdateSkillsOfPerson = updateSkillsOfPerson
                };

                await Mediator.Send(command);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Метод удаляет сотрудника по его идентификатору
        /// </summary>
        /// <param name="deletePersonCommand"></param>
        /// <returns></returns>
        [HttpDelete("Person")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeletePerson(DeletePersonCommand deletePersonCommand)
        {
            try
            {
                await Mediator.Send(deletePersonCommand);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Метод предоставляет информацию о сотруднике по его идентификатору
        /// </summary>
        /// <param name="getPersonQuery"></param>
        /// <returns></returns>
        [HttpGet("Person")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PersonVM>> GetPesonById(int id)
        {
            try
            {
                var getPersonQuery = new GetPersonQuery
                {
                    Id = id
                };

                return Ok(await Mediator.Send(getPersonQuery));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Метод предоставляет информацию обо всех сотрудниках
        /// </summary>
        /// <param name="getPersonQuery"></param>
        /// <returns></returns>
        [HttpGet("Persons")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PersonVM>>> GetPesons()
        {
            try
            {
                var getListPersonQuery = new GetListPersonQuery();
                return Ok(await Mediator.Send(getListPersonQuery));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
