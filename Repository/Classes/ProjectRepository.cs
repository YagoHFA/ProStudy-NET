using HFA.DB.Model;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using ProStudy_NET.Repository.Interfaces;

namespace ProStudy_NET.Repository.Classes
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(DbContext context) : base(context)
        {
        }
    }
}