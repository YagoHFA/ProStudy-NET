using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProStudy_NET.Component.Exceptions.Models;
using ProStudy_NET.Models.DTO.VideoDTO;
using ProStudy_NET.Services.Classes;
using ProStudy_NET.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ProStudy_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Controller to handler Video operations.")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService videoService;

        public VideoController(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        [HttpGet("{videoId}")]
        [AllowAnonymous]
        [SwaggerOperation]
        [SwaggerResponse(200, "Video info by given id.", typeof(VideoMinDTO))]
        [SwaggerResponse(404, "Not Found")]
        public ActionResult FindById(string videoId)
        {
            try
            {
                VideoMinDTO videoMinDTO = videoService.FindById(videoId);
                return Ok(videoMinDTO);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}