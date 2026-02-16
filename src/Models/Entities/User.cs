using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HFA.Auth.Interfaces;

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
        public string Password { get; set; }= string.Empty;

        [Column("useremail")]
        [Required]
        public string Email { get; set; } = string.Empty;

        public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();

        public virtual ICollection<Project> UserProjects { get; set; } = new List<Project>();

        public virtual ICollection<SkillTest> SkillTests { get; set; } = new List<SkillTest>();
        
        [NotMapped]
        public ICollection<Permission> Permissions { get => this.UserRoles.Select(r => (Permission)r.Role).ToList();}
    }
}