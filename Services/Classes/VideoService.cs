using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Component.Exceptions.Models;
using ProStudy_NET.Models.DTO.VideoDTO;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class VideoService : IVideoService
    {
        private readonly UnitWork unitWork;

        public VideoService(UnitWork unitWork)
        {
            this.unitWork = unitWork;
        }

        public void DeleteById(string id)
        {
            unitWork.Videos.DeleteById(id);
            unitWork.Complete();
        }

        public VideoMinDTO FindMinById(string id)
        {
            Video? video = unitWork.Videos.FindById(id);
            if (video == null)
            {
                throw new Exception("Video not found");
            }
            return new VideoMinDTO(video);
        }

        public VideoMinDTO FindByVideoName(string videoName)
        {
            Video? video = unitWork.Videos.FindByVideoName(videoName);

            if (video == null)
                throw new NotFoundException("Video not found");

            return new VideoMinDTO(video);
        }

        public VideoMinDTO FindById(string id)
        {
            Video? video = unitWork.Videos.FindById(id);

            if (video == null)
                throw new NotFoundException("Video not found");

            return new VideoMinDTO(video);    
        }

        public VideoInfoDTO FindByName(string videoName)
        {
            Video? video = unitWork.Videos.FindByVideoName(videoName);

            if (video == null)
                throw new NotFoundException("Video not found");

            return new VideoInfoDTO(video);
        }

        public void Save(VideoCadDTO videoCadDTO)
        {
            Category? category = unitWork.Categories.Find(x => x.CategoryName.Equals(videoCadDTO.category));
            if (category != null)
            {
                Video videoToSave = new Video
                {
                    VideoId = videoCadDTO.videoId,
                    VideoThumbnail = videoCadDTO.thumb,
                    VideoTitle = videoCadDTO.videoTitle,
                    Category = category,
                    CategoryId = category.CategoryId
                };
                unitWork.Videos.Add(videoToSave);
            }
            unitWork.Complete();
        }
    }
}