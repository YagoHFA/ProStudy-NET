using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProStudy_NET.Models.Entities
{
    [Table("Project")]
    public class Project
    {
        [Key]
        [Column("projectid")]
        public string ProjectId { get; private set; }

        [Required]
        [StringLength(255)]
        [Column("projectname")]
        public required string ProjectName { get; set; }

        [Column("projectdescription")]
        public string? ProjectDescription { get; set; }

        [Column("projectURL")]
        public string? ProjectURL { get; set; }

        public required List<User> ProjectsUser { get; set; }

        [InverseProperty("ProjectList")]
        public required List<Category> Tools { get; set; }

        public Project() {
            this.ProjectId = string.Empty;
        }

        public Project(string projectName, string projectOwner, long userId)
        {
            this.ProjectId = GenerateProjectId(projectName, projectOwner, userId);
        }

        public string GenerateProjectId(string projectName, string projectOwner, long userId)
        {
            string projectNamePart = projectName.Length >= 3 ? projectName.Substring(0, 3) : projectName;
            string projectOwnerPart = projectOwner.Length >= 2 ? projectOwner.Substring(0, 2) : projectOwner;
            return $"{projectNamePart.ToLower()}#{projectOwnerPart.ToLower()}{userId}";
        }
    }
}