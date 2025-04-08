using ProStudy_NET.Component.DB.Unity;
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

        public IQueryable<CategoryMinDTO> GetAllCategoryName()
        {
            return unitWork.CategoryRepository.GetAll().Select(x => new CategoryMinDTO(x));
        }

        public IQueryable<Category> GetAllTests()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAllVideos()
        {
            throw new NotImplementedException();
        }
    }
}