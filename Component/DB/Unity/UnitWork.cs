using HFA.DB.Interfaces;
using ProStudy_NET.Repository.Classes;
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

        public UnitWork(ProStudyDB context){
            this.context = context;
            Users = new UserRepository(context);
            Roles = new RoleRepository(context);
            Categories = new CategoryRepository(context);
            Products = new ProjectRepository(context);
            Videos = new VideoRepository(context);
            Tests = new TestRepository(context);
            Questions = new QuestionRepository(context);
            Answers = new AnswerRepository(context);
        
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