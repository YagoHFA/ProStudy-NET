using ProStudy_NET.Models.DTO;

namespace ProStudy_NET.Services.Interfaces
{
    public interface iUserServices
    {
        LoadUserDTO GetByUserName(string username);
    }
}