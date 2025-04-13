using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProStudy_NET.Models.DTO.CategoryDTO;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        
        [HttpGet("/list/videos")]
        [AllowAnonymous]
        public ActionResult<List<CategoryVideoDTO>> findAllVideos() {
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
        public ActionResult<List<CategoryTestDTO>> findAllTests() {
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
        public ActionResult<List<CategoryMinDTO>> listCategories(){
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
        public ActionResult<List<CategoryVideoDTO>> listVideosByCategory(string categoryName){
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
        public ActionResult<List<CategoryTestDTO>> listTestsByCategory(string categoryName){
            try{
                List<CategoryTestDTO> testsList = categoryService.findTestByCategory(categoryName).ToList();
                return Ok(testsList);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPost("/create")]
        public ActionResult createCategory([FromBody] CategoryMinDTO createCategory){
            try{
                categoryService.AddCategory(createCategory);
                return Ok("Category created successfully");
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        public ActionResult deleteCategory(string categoryName){
            try{
                categoryService.DeleteCategory(categoryName);
                return Ok("Category deleted successfully");
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}