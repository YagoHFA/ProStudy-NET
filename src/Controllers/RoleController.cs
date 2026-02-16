using Microsoft.AspNetCore.Mvc;
using ProStudy_NET.Services.Interfaces;

namespace ProStudy_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
    }
}