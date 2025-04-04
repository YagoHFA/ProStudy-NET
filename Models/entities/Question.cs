using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProStudy_NET.Models.Entities
{
    [Table("question")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("questionid")]
        public long QuestionId { get; set; }

        [Column("questiontext")]
        [StringLength(255)]
        public string QuestionText { get; set; } = string.Empty;

        [Column("questionimage")]
        [StringLength(255)]
        public string QuestionImage { get; set; } = string.Empty;

        public required string TestId { get; set; }

        [ForeignKey("TestId")]
        public required SkillTest Test { get; set; }

        public required List<Answer> AnswerList { get; set; }
    }
}