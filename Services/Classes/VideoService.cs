using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Models.DTO.VideoDTO;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class VideoService : IVideoService
    {
        private readonly UnitWork unitWork;

        public VideoService(UnitWork unitWork){
            this.unitWork = unitWork;
        }

        public void DeleteById(string id)
        {
            unitWork.Videos.DeleteById(id);
            unitWork.Complete();
        }

        public VideoMinDTO FindById(string id)
        {
            Video? video = unitWork.Videos.FindById(id);
            if(video == null){
                throw new Exception("Video not found");
            }
            return new VideoMinDTO(video);
        }
    }
}