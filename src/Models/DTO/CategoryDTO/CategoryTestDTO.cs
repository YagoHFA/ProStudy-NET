using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProStudy_NET.Models.DTO.TestDTO;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Models.DTO.CategoryDTO
{
    public class CategoryTestDTO
    {
        public long categoryId { get; set; }
        public string categoryName { get; set; }
        public List<TestMinDTO>? testList { get; set; }

        public CategoryTestDTO(Category entity)
        {
            categoryId = entity.CategoryId;
            categoryName = entity.CategoryName;
            if(entity.SkillTestList != null)
                testList = entity.SkillTestList.Select(t => new TestMinDTO(t)).ToList();
        }
    }
}