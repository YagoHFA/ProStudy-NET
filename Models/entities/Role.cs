using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace ProStudy_NET.Models.entities
{
    [Table("roles")]
    public class Role : IdentityRole
    {
        [Key] 
        [Column("roleid")] 
        public override string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(255)]
        [Column("rolename")]
        public string RoleName { get; set; } = string.Empty;

        public List<User>? Users { get; set; }

        public Role() : base() {}

        public Role(string roleName) : base(roleName)
        {
            RoleName = roleName;
        }
    }
}