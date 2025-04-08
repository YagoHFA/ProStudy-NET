using ProStudy_NET.Models.DTO.VideoDTO;

namespace ProStudy_NET.Services.Interfaces
{
    public interface IVideoService
    {
        VideoMinDTO FindById(string id);

        void DeleteById(string id);
    }
}