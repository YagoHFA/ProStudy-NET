using HFA.DB.Model;
using Microsoft.EntityFrameworkCore;
using ProStudy_NET.Component.DB;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;

namespace ProStudy_NET.Repository.Classes
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProStudyDB context) : base(context)
        {
        }

        public IQueryable<Category> findTestByCategory(string categoryName)
        {
            return dbSet.Include(c => c.SkillTestList).Where(c => c.Equals(categoryName));
        }

        public IQueryable<Category> findVideosByCategory(string categoryName)
        {
            return dbSet.Include(c => c.VideoList).Where(c => c.Equals(categoryName));
        }
    }
}