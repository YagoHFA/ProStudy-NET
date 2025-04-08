using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Models.DTO.CategoryDTO
{
    public class CategoryMinDTO
    {
        public required string name { get; set; }

        public CategoryMinDTO(Category entity){
            name = entity.CategoryName;
        }
    }
}