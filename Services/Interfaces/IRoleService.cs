using ProStudy_NET.Models.DTO;

namespace ProStudy_NET.Services.Interfaces
{
    public interface IRoleService
    {
        RoleInfoDTO FindById(string id);

        RoleInfoDTO FindByRoleName(string name);
    }
}