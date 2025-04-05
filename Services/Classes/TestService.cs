using ProStudy_NET.Repository.Interfaces;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class TestService :ITestService
    {
        private readonly ITestRepository testRepository;

        public TestService(ITestRepository testRepository){
            this.testRepository = testRepository;
        }
    }
}