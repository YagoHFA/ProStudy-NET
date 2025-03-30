using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProStudy_NET.Models.entities
{
    [Table("tests")]
    public class SkillTest
    {
        [Key] 
        [Column("testid")] 
        public string TestId { get; set; } = string.Empty;

        [Required] 
        [StringLength(255)] 
        [Column("testtitle")] 
        public required string TestTitle { get; set; } = string.Empty;

        [StringLength(int.MaxValue)] 
        [Column("testdescriptionlong", TypeName = "text")]
        public required string TestLongDescription { get; set; }

        [StringLength(100)] 
        [Column("testdescriptionshort")] 
        public required string TestShortDescription { get; set; }

        [StringLength(500)] 
        [Column("badgeurl")] 
        public required string BadgeURL { get; set; }

        public required List<Question> Questions { get; set; }

        public List<User>? Users { get; set; }

        [InverseProperty("SkillTests")]
        public required List<Category> CategoryList { get; set; }
    
    }
}