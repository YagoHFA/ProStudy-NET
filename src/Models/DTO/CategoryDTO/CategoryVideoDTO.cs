using ProStudy_NET.Models.Entities;
using ProStudy_NET.Models.DTO.VideoDTO;

namespace ProStudy_NET.Models.DTO.CategoryDTO
{
    public class CategoryVideoDTO
    {
        public long categoryId { get; set; }
        public string categoryName { get; set; }

        public List<VideoMinDTO>? videoList { get; set; }

        public CategoryVideoDTO(Category entity) { 
            categoryId = entity.CategoryId;
            categoryName = entity.CategoryName;
            if (entity.VideoList != null)
                videoList  = entity.VideoList.Select(video => new VideoMinDTO(video)).ToList();
        }

    }
}