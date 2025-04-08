using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProStudy_NET.Models.DTO.VideoDTO
{
    public class VideoInfoDTO
    {
        public required string videoId { get; set; }
        public required string videoTitle { get; set; }  
        public required string thumb { get; set; }
    }
}