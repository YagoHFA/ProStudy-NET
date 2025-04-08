using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProStudy_NET.Models.DTO.User;
using ProStudy_NET.Services.Interfaces;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase{

    private readonly iUserServices userServices;

    public UserController(iUserServices userServices){
        this.userServices = userServices;
    }

    [HttpGet("/load/username={username}")]
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

    [HttpGet("/load/id={id}")]
    public ActionResult<LoadUserDTO> GetById([FromRoute] long id) 
    {
        try
        {
            LoadUserDTO userDTO = userServices.GetById(id);
            return Ok(userDTO);
        }
        catch(ArgumentNullException ex){
            return NotFound(ex.Message);
        }
        
    }
}