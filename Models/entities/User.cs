using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProStudy_NET.Models.Entities
{
    [Table("Users")]
    public class User : UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("userid")]
        public long Id { get; set; }

        [Column("username")]
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Column("userpassword")]
        [Required]
        public string PasswordHash { get; set; }= string.Empty;

        [Column("useremail")]
        [Required]
        public string Email { get; set; } = string.Empty;

        public virtual ICollection<Role> UserRoles { get; set; } = new List<Role>();

        public virtual ICollection<Project> UserProjects { get; set; } = new List<Project>();

        public virtual ICollection<SkillTest> SkillTests { get; set; } = new List<SkillTest>();
        public ICollection<Role> GetRoles { get => this.UserRoles ; set => this.UserRoles = value;}
    }
}