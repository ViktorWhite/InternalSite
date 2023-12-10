using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Skill.Commands.CreateSkill;
using InternalSite.Application.Skill.Commands.DeleteSkill;
using InternalSite.Application.Skill.Commands.UpdateSkill;
using InternalSite.Application.Skill.Queries.Common;
using InternalSite.Application.Skill.Queries.GetListSkillsQuery;
using InternalSite.Application.Skill.Queries.GetSkillQuery;
using Microsoft.AspNetCore.Mvc;

namespace InternalSite.WebApi.Controllers
{
    /// <summary>
    /// Контроллер навыков
    /// </summary>
    [ApiController]
    public class SkillsController : BaseController
    {
        /// <summary>
        /// Метод создания нового навыка
        /// </summary>
        /// <param name="createSkillCommand"></param>
        /// <returns></returns>
        [HttpPost("Skill")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreateSkill(CreateSkillCommand createSkillCommand)
        {
            try
            {
                var newSkill = await Mediator.Send(createSkillCommand);
                return Created("", newSkill);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Метод изменения существующего навыка
        /// </summary>
        /// <param name="updateSkillCommand"></param>
        /// <returns></returns>
        [HttpPut("Skill")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateSkill(UpdateSkillCommand updateSkillCommand)
        {
            try
            {
                await Mediator.Send(updateSkillCommand);
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
        /// Метод удаления навыка по его идентификатору
        /// </summary>
        /// <param name="deleteSkillCommand"></param>
        /// <returns></returns>
        [HttpDelete("Skill")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteSkill(DeleteSkillCommand deleteSkillCommand)
        {
            try
            {
                await Mediator.Send(deleteSkillCommand);
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
        /// Метод предоставления информации о навыке по его идентификатору
        /// </summary>
        /// <param name="getSkillQuery"></param>
        /// <returns></returns>
        [HttpGet("Skill")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SkillVM>> GetSkillById(int id)
        {
            try
            {
                var getSkillQuery = new GetSkillQuery
                {
                    Id = id
                };

                return Ok(await Mediator.Send(getSkillQuery));
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
        /// Метод предоставления информации обо всех навыках
        /// </summary>
        /// <param name="getListSkillsQuery"></param>
        /// <returns></returns>
        [HttpGet("Skills")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<SkillVM>>> GetSkills()
        {
            try
            {
                var getListSkillsQuery = new GetListSkillsQuery();
                return Ok(await Mediator.Send(getListSkillsQuery));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
