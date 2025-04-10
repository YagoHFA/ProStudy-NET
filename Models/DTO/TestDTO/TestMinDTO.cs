using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Models.DTO.TestDTO
{
    public class TestMinDTO
    {
        public string testTitle { get; set; }
        public string testShortDescription { get; set; }
        public string testLongDescription { get; set; }
        public string testId { get; set; }
        public string testBadgeUrl { get; set; }
        public long testQuestionNumber { get; set; }

        public TestMinDTO(SkillTest entity) { 
            testTitle = entity.TestTitle;
            testShortDescription = entity.TestShortDescription;
            testLongDescription = entity.TestLongDescription;
            testId = entity.TestId;
            testBadgeUrl = entity.BadgeURL;
            testQuestionNumber = entity.Questions.Count;
        }
    }
}