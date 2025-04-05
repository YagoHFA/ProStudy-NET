using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Services.Classes
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectService projectService;

        public ProjectService(IProjectService projectService){
            this.projectService = projectService;
        }
    }
}