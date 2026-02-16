using ProStudy_NET.Component.DB.Unity;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class ProjectService : IProjectService
    {
        private readonly UnitWork unitWork;

        public ProjectService(UnitWork unitWork){
            this.unitWork = unitWork;
        }
    }
}