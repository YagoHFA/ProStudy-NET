using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProStudy_NET.Models.Interfaces;


namespace ProStudy_NET.Models.Entities
{
    [Table("roles")]
    public class Role : RoleDetails
    {
        [Key] 
        [Column("roleid")] 
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(255)]
        [Column("rolename")]
        public string RoleName { get; set; } = string.Empty;

        public List<User>? Users { get; set; }

        public Role() : base() {}

        public Role(string roleName)
        {
            RoleName = roleName;
        }

        public string getPermission()
        {
            return this.RoleName;
        }
    }
}