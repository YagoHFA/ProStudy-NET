using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HFA;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IQueryable<Category> findVideosByCategory(string categoryName);

        IQueryable<Category> findTestByCategory(string categoryName);
    }
}