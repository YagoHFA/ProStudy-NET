using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProStudy_NET.Models.DTO.CategoryDTO;
using ProStudy_NET.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ProStudy_NET.Controllers
{
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
        
        [HttpGet("/list/videos")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Returns all videos grouped by category.",
            Description = "Returns all videos grouped by category."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "A list of categories with associated videos.", typeof(List<CategoryVideoDTO>))] 
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request.", typeof(List<CategoryVideoDTO>))]
        public ActionResult<List<CategoryVideoDTO>> FindAllVideos() {
            try{
                List<CategoryVideoDTO> videosList = categoryService.GetAllVideos().ToList();
                return Ok(videosList);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/list/tests")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Returns all tests grouped by category.",
            Description = "Returns all tests grouped by category."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "A list of categories with associated tests.", typeof(List<CategoryTestDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request.")]
        public ActionResult<List<CategoryTestDTO>> FindAllTests() {
            try{
                List<CategoryTestDTO> testsList = categoryService.GetAllTests().ToList();
                return Ok(testsList);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/list")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Returns all categories without related entities.",
            Description = "Returns all categories without related entities."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "A list of categories.", typeof(List<CategoryMinDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request.")]
        public ActionResult<List<CategoryMinDTO>> ListCategories(){
            try{
                List<CategoryMinDTO> categoriesList = categoryService.GetAllCategoryName().ToList();
                return Ok(categoriesList);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
    
        }

        [HttpGet("/list/videos/{categoryName}")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Returns a category with all its associated videos.",
            Description = "Returns a category with all its associated videos."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "A category with all associated videos.", typeof(CategoryVideoDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request.")]	
        public ActionResult<List<CategoryVideoDTO>> ListVideosByCategory(string categoryName){
            try{
                List<CategoryVideoDTO> videosList = categoryService.findVideoByCategory(categoryName).ToList();
                return Ok(videosList);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/list/tests/{categoryName}")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Returns a category with all its associated tests.",
            Description = "Returns a category with all its associated tests."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "A category with all associated tests.", typeof(CategoryTestDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request.")]
        public ActionResult<List<CategoryTestDTO>> ListTestsByCategory(string categoryName){
            try{
                List<CategoryTestDTO> testsList = categoryService.findTestByCategory(categoryName).ToList();
                return Ok(testsList);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPost("/create")]
        [Authorize(Roles ="CO3")]
        [SwaggerOperation(
            Summary = "Create a category.",
            Description = "Create a category."
        )]
        [SwaggerResponse(StatusCodes.Status201Created, "Category created successfully.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request.")]
        public ActionResult createCategory([FromBody] CategoryMinDTO createCategory){
            try{
                categoryService.AddCategory(createCategory);
                return Ok("Category created successfully");
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/delete")]
        [Authorize(Roles = "CO3")]
        [SwaggerOperation(
            Summary = "Delete a category.",
            Description = "Delete a category."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Category deleted successfully.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request.")]
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