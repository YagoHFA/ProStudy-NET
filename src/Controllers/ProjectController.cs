using Microsoft.AspNetCore.Mvc;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
    }
}