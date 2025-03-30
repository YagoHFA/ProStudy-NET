using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProStudy_NET.Models.entities
{
    [Table("Users")]
    public class User : IdentityUser<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("userid")]
        public override long Id { get; set; }

        [Column("username")]
        [Required]
        public override string? UserName { get; set; }

        [Column("userpassword")]
        [Required]
        public override string? PasswordHash { get; set; }

        [Column("useremail")]
        [Required]
        public override string? Email { get; set; }

        public virtual ICollection<Role> UserRoles { get; set; } = new List<Role>();

        public virtual ICollection<Project> UserProjects { get; set; } = new List<Project>();

        public virtual ICollection<SkillTest> SkillTests { get; set; } = new List<SkillTest>();

        public override bool LockoutEnabled => false;
        public override bool TwoFactorEnabled => false;

    }
}