

using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Models.DTO.VideoDTO
{
    public class VideoInfoDTO
    {
        public string videoId { get; set; }
        public string videoTitle { get; set; }
        public string thumb { get; set; }

        public VideoInfoDTO(Video entity){
            videoId = entity.VideoId;
            videoTitle = entity.VideoTitle;
            thumb = entity.VideoThumbnail;
        }
    }
}