using HFA;
using ProStudy_NET.Models.DTO.VideoDTO;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Repository.Interfaces
{
    public interface IVideoRepository : IRepository<Video>
    {
        Video? FindMinByVideoId(string id);

        Video? FindByVideoName(string videoName);
    }
}