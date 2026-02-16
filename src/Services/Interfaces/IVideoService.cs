using ProStudy_NET.Models.DTO.VideoDTO;

namespace ProStudy_NET.Services.Interfaces
{
    public interface IVideoService
    {
        VideoMinDTO FindMinById(string id);

        void DeleteById(string id);

        VideoMinDTO FindById(string id);
        VideoInfoDTO FindByName(string videoName);

        void Save(VideoCadDTO videoCadDTO);
    }
}