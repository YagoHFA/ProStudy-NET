using ProStudy_NET.Models.DTO.CategoryDTO;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Services.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<CategoryVideoDTO> GetAllVideos();

        IQueryable<CategoryTestDTO> GetAllTests();

        IQueryable<CategoryMinDTO> GetAllCategoryName();

        void AddCategory(CategoryMinDTO category);

        void DeleteCategory(int id);

        void DeleteCategory(CategoryMinDTO categoryName);

        IQueryable<CategoryVideoDTO> findVideoByCategory(string categoryName);

        IQueryable<CategoryTestDTO> findTestByCategory(string categoryName);
    }
}