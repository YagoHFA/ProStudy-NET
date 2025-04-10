using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Component.Exceptions.Models;
using ProStudy_NET.Models.DTO.CategoryDTO;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitWork unitWork;

        public CategoryService(UnitWork unitWork){
            this.unitWork = unitWork;
        }

        public void AddCategory(CategoryMinDTO category)
        {
            Category newCategory = new Category{CategoryName = category.name};
            unitWork.Categories.Add(newCategory);
            unitWork.Complete();
        }

        public void DeleteCategory(int id)
        {
            unitWork.Categories.DeleteById(id);
            unitWork.Complete();
        }

        public IQueryable<CategoryTestDTO> findTestByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CategoryVideoDTO> findVideoByCategory(string categoryName)
        {
            IQueryable<Category>? categories = unitWork.Categories.findVideosByCategory(categoryName);
            if(categories == null){
                throw new NotFoundException($"category '{categoryName}' not found");
            }

            return categories.Select(c => new CategoryVideoDTO(c));
        }

        public IQueryable<CategoryMinDTO> GetAllCategoryName()
        {
            IQueryable<Category>? categories = unitWork.Categories.FindAll();

            if(categories == null){
                throw new NotFoundException("No categories have been registered.");
            }
            return categories.Select(c => new CategoryMinDTO(c));
        }

        public IQueryable<CategoryTestDTO> GetAllTests()
        {
            IQueryable<Category>? categories = unitWork.Categories.FindAll();
            if(categories == null){
                throw new NotFoundException("No categories have been registered.");
            }
            return categories.Select(c => new CategoryTestDTO(c));
        }

        public IQueryable<CategoryVideoDTO> GetAllVideos()
        {
            IQueryable<Category>? categories = unitWork.Categories.FindAll();
            if(categories == null){
                throw new NotFoundException("No categories have been registered.");
            }
            return categories.Select(c => new CategoryVideoDTO(c));
        }
    }
}