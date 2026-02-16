using HFA.DB.Model;
using ProStudy_NET.Component.DB;
using ProStudy_NET.Models.Entities;
using ProStudy_NET.Repository.Interfaces;

namespace ProStudy_NET.Repository.Classes
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ProStudyDB context) : base(context)
        {
        }
    }
}