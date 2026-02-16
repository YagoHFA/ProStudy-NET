using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HFA.Auth.Interfaces;

namespace ProStudy_NET.Models.Entities
{
    [Table("roles")]
    public class Role : Permission
    {
        [Key] 
        [Column("roleid")] 
        public required string Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("rolename")]
        public string Permission { get; set; } = string.Empty;

        public List<UserRoles>? UserRoles { get; set; }

        public Role() : base() {}

        public Role(string roleName)
        {
            Permission = roleName;
        }

        public string getPermission()
        {
            return this.Permission;
        }
    }
}