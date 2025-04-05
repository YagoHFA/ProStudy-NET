using ProStudy_NET.Repository.Interfaces;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            this.answerRepository = answerRepository;
        }
    }
}