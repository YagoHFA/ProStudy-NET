using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProStudy_NET.Models.Entities
{
    [Table("user_roles")]
    public class UserRoles
    {
        [Key]
        [Column("userid")]
        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public required User User { get; set; }

        [Key]
        [Column("roleid")]
        public required string RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public required Role Role { get; set; }
    }
}