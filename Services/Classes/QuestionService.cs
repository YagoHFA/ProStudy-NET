using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Repository.Classes;
using ProStudy_NET.Repository.Interfaces;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class QuestionService : IQuestionService
    {
        private readonly UnitWork unitWork;

        public QuestionService(UnitWork unitWork){
            this.unitWork = unitWork;
        }
    }
}