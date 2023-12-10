using InternalSite.Application.Category.Queries.Common;
using InternalSite.Application.Category.Commands.CreateCategory;
using InternalSite.Application.Category.Commands.DeleteCategory;
using InternalSite.Application.Category.Commands.UpdateCategory;
using InternalSite.Application.Category.Queries.GetCategoryQuery;
using Microsoft.AspNetCore.Mvc;
using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Category.Queries.GetCategoriesQuery;

namespace InternalSite.WebApi.Controllers
{
    /// <summary>
    /// Контроллер структурных подразделений
    /// </summary>
    [ApiController]
    public class CategoriesController : BaseController
    {
        /// <summary>
        /// Метод создает новое структурное подразделение
        /// </summary>
        /// <param name="сreateCategoryCommand"></param>
        /// <returns></returns>
        [HttpPost("Category")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreateCategory(CreateCategoryCommand сreateCategoryCommand)
        {
            try
            {
                var newCategory = await Mediator.Send(сreateCategoryCommand);
                return Created("", newCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Метод изменяет существующее структурное подразделение
        /// </summary>
        /// <param name="updateCategoryCommand"></param>
        /// <returns></returns>
        [HttpPut("Category")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            try
            {
                await Mediator.Send(updateCategoryCommand);
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
        /// Метод удаляет структурное подразделение по его идентификатору
        /// </summary>
        /// <param name="deleteCategoryCommand"></param>
        /// <returns></returns>
        [HttpDelete("Category")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteCategory(DeleteCategoryCommand deleteCategoryCommand)
        {
            try
            {
                await Mediator.Send(deleteCategoryCommand);
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
        /// Метод предоставляет информацию о структурном подразделении по его идентификатору
        /// </summary>
        /// <param name="getCategoryQuery"></param>
        /// <returns></returns>
        [HttpGet("Category")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryVM>> GetCategoryById(int id)
        {
            try
            {
                var getCategoryQuery = new GetCategoryQuery
                {
                    Id = id
                };

                return Ok(await Mediator.Send(getCategoryQuery));
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
        /// Метод предоставляет информацию обо всех структурных подразделениях
        /// </summary>
        /// <param name="getCategoryQuery"></param>
        /// <returns></returns>
        [HttpGet("Categories")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<CategoryVM>>> GetCategories()
        {
            try
            {
                var listCategory = new GetListCategoryQuery();
                return Ok(await Mediator.Send(listCategory));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
