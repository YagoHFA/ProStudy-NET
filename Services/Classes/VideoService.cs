using ProStudy_NET.Models.DTO;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository videoRepository;

        public VideoService(IVideoRepository videoRepository){
            this.videoRepository = videoRepository;
        }

        public void DeleteById(string id)
        {
            videoRepository.DeleteById(id);
        }

        public VideoInfoDTO FindById(string id)
        {
            Video? video = videoRepository.FindById(id);
            if(video == null){
                throw new Exception("Video not found");
            }
            return new VideoInfoDTO{videoTitle = video.VideoTitle, videoId = video.VideoId, thumb = video.VideoThumbnail};
        }
    }
}