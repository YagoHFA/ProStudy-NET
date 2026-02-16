using Microsoft.AspNetCore.Mvc;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService testService;

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }
    }
}