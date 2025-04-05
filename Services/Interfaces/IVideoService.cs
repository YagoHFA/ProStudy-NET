using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProStudy_NET.Models.DTO;

namespace ProStudy_NET.Services.Interfaces
{
    public interface IVideoService
    {
        VideoInfoDTO FindById(string id);

        void DeleteById(string id);
    }
}