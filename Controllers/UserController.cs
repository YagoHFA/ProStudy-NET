using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProStudy_NET.Models.DTO;
using ProStudy_NET.Services;
using ProStudy_NET.Services.Interfaces;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase{

    private readonly iUserServices userServices;

    public UserController(iUserServices userServices){
        this.userServices = userServices;
    }

    [HttpGet("/load/{username}")]
    [AllowAnonymous]
    public ActionResult<LoadUserDTO> GetByUserName([FromRoute] string username) 
    {
        try
        {
            LoadUserDTO userDTO = userServices.GetByUserName(username);
            return Ok(userDTO);
        }
        catch(ArgumentNullException ex){
            return NotFound(ex.Message);
        }
        
    }
}