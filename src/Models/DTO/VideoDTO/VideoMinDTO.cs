using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Models.DTO.VideoDTO
{
    public class VideoMinDTO
    {
        public string videoId { get; set; }
        public string videoTitle { get; set; }
        public string thumb { get; set; }

        public VideoMinDTO(Video entity){
            videoId = entity.VideoId;
            videoTitle = entity.VideoTitle;
            thumb = entity.VideoThumbnail;
        }
    }
}