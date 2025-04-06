using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Repository.Interfaces;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class TestService :ITestService
    {
        private readonly UnitWork unitWork;

        public TestService(UnitWork unitWork){
            this.unitWork = unitWork;
        }
    }
}