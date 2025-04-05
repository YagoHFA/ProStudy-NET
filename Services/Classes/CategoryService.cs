using ProStudy_NET.Repository.Interfaces;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository){
            this.categoryRepository = categoryRepository;
        }
    }
}