using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProStudy_NET.Models.DTO.ProjectDTO;
using ProStudy_NET.Models.DTO.RoleDTO;

namespace ProStudy_NET.Models.DTO.UserDTO
{
    public class LoadUserDTO
    {
        public long Id { get; set; }
        public required string UserName { get; set; }
        public required string Email;
        public List<RolePermissionDTO> roleInfos = new List<RolePermissionDTO>();
        public List<ProjectMinViewDTO> projects = new List<ProjectMinViewDTO>();
    }
}