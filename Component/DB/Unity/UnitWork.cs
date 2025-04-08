using HFA.DB.Interfaces;
using ProStudy_NET.Repository.Interfaces;

namespace ProStudy_NET.Component.DB.Unity
{
    public class UnitWork : IUnitOfWorks
    {
        private readonly ProStudyDB context;

        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public ICategoryRepository Categories { get; }
        public IProjectRepository Products { get; }
        public IVideoRepository Videos { get; }
        public ITestRepository Tests { get; }
        public IQuestionRepository Questions { get; }
        public IAnswerRepository Answers { get; }

        public UnitWork(ProStudyDB context,
                        IUserRepository userRepository,
                        IRoleRepository roleRepository,
                        ICategoryRepository categoryRepository,
                        IProjectRepository projectRepository,
                        IVideoRepository videoRepository,
                        ITestRepository testRepository,
                        IQuestionRepository questionRepository,
                        IAnswerRepository answerRepository)
        {
            this.context = context;

            Users = userRepository;
            Roles = roleRepository;
            Categories = categoryRepository;
            Products = projectRepository;
            Videos = videoRepository;
            Tests = testRepository;
            Questions = questionRepository;
            Answers = answerRepository;
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}