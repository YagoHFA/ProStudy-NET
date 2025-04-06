using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitWork unitWork;

        public CategoryService(UnitWork unitWork){
            this.unitWork = unitWork;
        }
    }
}