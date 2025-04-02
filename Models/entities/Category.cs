using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProStudy_NET.Models.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("categoryId")]
        public long CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        [Column("categoryName")]
        public required string CategoryName { get; set; }

        public List<Video>? VideoList { get; set; }

        [InverseProperty("CategoryList")] 
        public List<SkillTest>? SkillTestList { get; set; }

        [InverseProperty("Tools")] 
        public List<Project>? ProjectList { get; set; }
    }
}