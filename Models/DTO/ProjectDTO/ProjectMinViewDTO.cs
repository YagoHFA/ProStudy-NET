using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProStudy_NET.Models.DTO.CategoryDTO;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Models.DTO.ProjectDTO
{
    public class ProjectMinViewDTO
    {
        public required string projectName { get; set; }
        public string? projectDescription { get; set; }
        public List<CategoryMinDTO> tools { get; set; } = new List<CategoryMinDTO>();
        public string? projectUrl { get; set; } = string.Empty;

        public ProjectMinViewDTO(Project project)
        {
            projectName = project.ProjectName;
            projectDescription = project.ProjectDescription;
            projectUrl = project.ProjectURL;
            foreach (var tool in project.Tools)
            {
                tools.Add(new CategoryMinDTO(tool));
            }
        }
    }
}