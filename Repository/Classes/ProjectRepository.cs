using HFA.DB.Model;
using Microsoft.Build.Evaluation;
using ProStudy_NET.Component.DB;
using ProStudy_NET.Repository.Interfaces;

namespace ProStudy_NET.Repository.Classes
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ProStudyDB context) : base(context)
        {
        }
    }
}