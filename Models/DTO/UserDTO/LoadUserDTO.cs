using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProStudy_NET.Models.DTO.ProjectDTO;
using ProStudy_NET.Models.DTO.RoleDTO;
using ProStudy_NET.Models.DTO.TestDTO;

namespace ProStudy_NET.Models.DTO.UserDTO
{
    public class LoadUserDTO
    {
        public long Id { get; set; }
        
        public required string UserName { get; set; }

        public required string Email { get; set; }

        public List<RolePermissionDTO> RoleInfos { get; set; } = new List<RolePermissionDTO>();

        public List<ProjectMinViewDTO> Projects { get; set; } = new List<ProjectMinViewDTO>();


        public List<TestInfoDTO> Skills { get; set; } = new List<TestInfoDTO>();
    }
}