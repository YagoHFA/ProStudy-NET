using HFA.DB.Model;
using Microsoft.EntityFrameworkCore;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;

namespace ProStudy_NET.Repository.Classes
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(DbContext context) : base(context)
        {
        }
    }
}