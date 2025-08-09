using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Models.DTO.VideoDTO
{
    public class VideoCadDTO
    {
        public String videoId;
        public String videoTitle;
        public String thumb;
        public String category;

        public VideoCadDTO(Video entity)
        {
            this.videoId = entity.VideoId;
            this.videoTitle = entity.VideoTitle;
            this.thumb = entity.VideoThumbnail;
            this.category = entity.Category.CategoryName;
        }
    }
}