using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProStudy_NET.Models.DTO.CategoryDTO;
using ProStudy_NET.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ProStudy_NET.Controllers
{
    /// <summary>
    /// Controller to handler Category operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Controller to handler Category operations.")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        
        /// <summary>
        /// Returns all videos grouped by category.
        /// </summary>
        /// <returns>A list of categories with associated videos.</returns>
        [HttpGet("/list/videos")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Returns all videos grouped by category.",
            Description = "Returns all videos grouped by category."
        )]
        [SwaggerResponse(200, "A list of categories with associated videos.", typeof(List<CategoryVideoDTO>))] 
        [SwaggerResponse(400, "Bad request.", typeof(List<CategoryVideoDTO>))]
        public ActionResult<List<CategoryVideoDTO>> findAllVideos() {
            try{
                List<CategoryVideoDTO> videosList = categoryService.GetAllVideos().ToList();
                return Ok(videosList);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Returns all tests grouped by category.
        /// </summary>
        /// <returns>A list of categories with associated tests.</returns>
        [HttpGet("/list/tests")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Returns all tests grouped by category.",
            Description = "Returns all tests grouped by category."
        )]
        [SwaggerResponse(200, "A list of categories with associated tests.", typeof(List<CategoryTestDTO>))]
        [SwaggerResponse(400, "Bad request.")]
        public ActionResult<List<CategoryTestDTO>> findAllTests() {
            try{
                List<CategoryTestDTO> testsList = categoryService.GetAllTests().ToList();
                return Ok(testsList);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Returns all categories without related entities.
        /// </summary>
        /// <returns>A list of categories.</returns>
        [HttpGet("/list")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Returns all categories without related entities.",
            Description = "Returns all categories without related entities."
        )]
        [SwaggerResponse(200, "A list of categories.", typeof(List<CategoryMinDTO>))]
        [SwaggerResponse(400, "Bad request.")]
        public ActionResult<List<CategoryMinDTO>> listCategories(){
            try{
                List<CategoryMinDTO> categoriesList = categoryService.GetAllCategoryName().ToList();
                return Ok(categoriesList);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
    
        }

        /// <summary>
        /// Returns a category with all its associated videos.
        /// </summary>
        /// <param name="categoryName">The category to be searched.</param>
        /// <returns>A category with all associated videos.</returns>
        [HttpGet("/list/videos/{categoryName}")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Returns a category with all its associated videos.",
            Description = "Returns a category with all its associated videos."
        )]
        [SwaggerResponse(200, "A category with all associated videos.", typeof(CategoryVideoDTO))]
        [SwaggerResponse(400, "Bad request.")]	
        public ActionResult<List<CategoryVideoDTO>> listVideosByCategory(string categoryName){
            try{
                List<CategoryVideoDTO> videosList = categoryService.findVideoByCategory(categoryName).ToList();
                return Ok(videosList);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Returns a category with all its associated tests.
        /// </summary>
        /// <param name="categoryName">The category to be searched.</param>
        /// <returns>A category with all associated tests.</returns>
        [HttpGet("/list/tests/{categoryName}")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Returns a category with all its associated tests.",
            Description = "Returns a category with all its associated tests."
        )]
        [SwaggerResponse(200, "A category with all associated tests.", typeof(CategoryTestDTO))]
        [SwaggerResponse(400, "Bad request.")]
        public ActionResult<List<CategoryTestDTO>> listTestsByCategory(string categoryName){
            try{
                List<CategoryTestDTO> testsList = categoryService.findTestByCategory(categoryName).ToList();
                return Ok(testsList);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Create a category.
        /// </summary>
        /// <param name="createCategory">Category to be created.</param>
        /// <returns>Returns a success or failure status.</returns>
        [HttpPost("/create")]
        [Authorize(Roles ="CO3")]
        [SwaggerOperation(
            Summary = "Create a category.",
            Description = "Create a category."
        )]
        [SwaggerResponse(201, "Category created successfully.")]
        [SwaggerResponse(400, "Bad request.")]
        public ActionResult createCategory([FromBody] CategoryMinDTO createCategory){
            try{
                categoryService.AddCategory(createCategory);
                return Ok("Category created successfully");
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Delete a category.
        /// </summary>
        /// <param name="categoryMin">The category to be deleted.</param>
        /// <returns>Returns a success or failure status.</returns>
        [HttpDelete("/delete")]
        [Authorize(Roles = "CO3")]
        [SwaggerOperation(
            Summary = "Delete a category.",
            Description = "Delete a category."
        )]
        [SwaggerResponse(200, "Category deleted successfully.")]
        [SwaggerResponse(400, "Bad request.")]
        public ActionResult deleteCategory([FromBody] CategoryMinDTO categoryMin){
            try{
                categoryService.DeleteCategory(categoryMin);
                return Ok("Category deleted successfully");
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}