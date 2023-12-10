using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Position.Commands.CreatePosition;
using InternalSite.Application.Position.Commands.DeletePosition;
using InternalSite.Application.Position.Commands.UpdatePosition;
using InternalSite.Application.Position.Queries.Common;
using InternalSite.Application.Position.Queries.GetPosition;
using InternalSite.Application.Position.Queries.GetPositions;
using Microsoft.AspNetCore.Mvc;

namespace InternalSite.WebApi.Controllers
{
    /// <summary>
    /// Контроллер должностей
    /// </summary>
    [ApiController]
    public class PositionsController : BaseController
    {
        /// <summary>
        /// Метод создает новую должность
        /// </summary>
        /// <param name="createPositionCommand"></param>
        /// <returns></returns>
        [HttpPost("Position")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreatePosition(CreatePositionCommand createPositionCommand)
        {
            try
            {
                var newCategory = await Mediator.Send(createPositionCommand);
                return Created("", newCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Метод изменяет существующую должность
        /// </summary>
        /// <param name="updatePositionCommand"></param>
        /// <returns></returns>
        [HttpPut("Position")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePosition(UpdatePositionCommand updatePositionCommand)
        {
            try
            {
                await Mediator.Send(updatePositionCommand);
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
        /// Метод удаляет должность по ее идентификатору
        /// </summary>
        /// <param name="deletePositionCommand"></param>
        /// <returns></returns>
        [HttpDelete("Position")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeletePosition(DeletePositionCommand deletePositionCommand)
        {
            try
            {
                await Mediator.Send(deletePositionCommand);
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
        /// Метод предоставляет информацию о должности по ее идентификатору
        /// </summary>
        /// <param name="getPositionQuery"></param>
        /// <returns></returns>
        [HttpGet("Position")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PositionVM>> GetPositionById(int id)
        {
            try
            {
                var getPositionQuery = new GetPositionQuery
                {
                    Id = id
                };

                return Ok(await Mediator.Send(getPositionQuery));
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
        /// Метод предоставляет информацию обо всех должностях
        /// </summary>
        /// <param name="getListPositionQuery"></param>
        /// <returns></returns>
        [HttpGet("Positions")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PositionVM>>> GetPositions()
        {
            try
            {
                var getListPositionQuery = new GetListPositionQuery();
                return Ok(await Mediator.Send(getListPositionQuery));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
