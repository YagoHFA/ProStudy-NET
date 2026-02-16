using System.Text.Json.Serialization;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Models.DTO.CategoryDTO
{
    public class CategoryMinDTO
    {
        public string name { get; set; }

        public CategoryMinDTO(Category entity){
            name = entity.CategoryName;
        }

        [JsonConstructor]
        public CategoryMinDTO(string name){
            this.name = name;
        }
    }
}