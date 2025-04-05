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
    }
}