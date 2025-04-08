using ProStudy_NET.Models.DTO.CategoryDTO;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Services.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAllVideos();

        IQueryable<Category> GetAllTests();

        IQueryable<CategoryMinDTO> GetAllCategoryName();
    }
}