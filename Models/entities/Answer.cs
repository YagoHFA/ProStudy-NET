using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProStudy_NET.Models.Entities
{
    [Table("answer")]
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("answerid")]
        public int AnswerId { get; set; }

        [Column("answertext")]
        public string Answers { get; set; } = string.Empty;

        [Column("answerpoints")]
        public decimal Points { get; set; }

        public long QuestionId { get; set;}

        [ForeignKey("QuestionId")]
        public required Question Question { get; set;}
    }
}