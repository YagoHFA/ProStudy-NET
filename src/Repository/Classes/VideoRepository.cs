using HFA.DB.Model;
using ProStudy_NET.Component.DB;
using ProStudy_NET.Models.DTO.VideoDTO;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;

namespace ProStudy_NET.Repository.Classes
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(ProStudyDB context) : base(context)
        {
        }

        public Video? FindByVideoName(string videoName)
        {
            return  dbSet
                    .Where(x => x.VideoTitle.Equals(videoName))
                    .FirstOrDefault();
        }

        public Video? FindMinByVideoId(string id)
        {
            return dbSet.Where(x => x.VideoId.Equals(id)).FirstOrDefault();
        }
    }
}