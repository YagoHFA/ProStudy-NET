using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class AnswerService : IAnswerService
    {
        private readonly UnitWork unitWork;

        public AnswerService(UnitWork unitWork)
        {
            this.unitWork = unitWork;
        }
    }
}