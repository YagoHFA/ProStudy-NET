using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProStudy_NET.Component.Exceptions.Models;
using ProStudy_NET.Models.DTO.UserDTO;
using ProStudy_NET.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("[controller]")]
[SwaggerTag("Endpoints for managing User operations")]
public class UserController: ControllerBase{

    private readonly iUserServices userServices;

    public UserController(iUserServices userServices){
        this.userServices = userServices;
    }

    /// <summary>
    /// Get user info by the given username.
    /// </summary>
    /// <param name="username">The username used to perform the search</param>
    /// <returns>User Info</returns>
    [HttpGet("/load/username={username}")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Get User by username",
        Description = "Returns the User info by username informed"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the User info", typeof(LoadUserDTO))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "If User is not found")]
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

    ///<summary>
    /// Get User by id
    ///<summary>
    /// <param  name="id"> User's unique identifier </param>
    /// <returns> User info </returns>
    /// <response code="200"> Returns the User info </response>
    /// <response code="404"> If User is not found </response>
    [HttpGet("/load/id={id}")]
    [SwaggerOperation(
        Summary = "Get User by id",
        Description = "Returns the User info by id informed"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the User info", typeof(LoadUserDTO))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "If User is not found")]
    [AllowAnonymous]
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

    [HttpPost("register/user")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Register a new User",
        Description = "Register a new User in the system"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "User registered successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid user data")]
    public ActionResult UserRegister(UserRegisterDTO userRegister){
        try{
            userServices.Create(userRegister);
            return Ok("User registered successfully.");
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("/login")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Login",
        Description = "Login in the system"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Login successfully")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Invalid credentials")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User not found")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid user data")]
    public ActionResult<string> Login([FromBody]UserLoginDTO userLogin){
        try{
            string token = userServices.Login(userLogin);
            return Ok(token);
        }
        catch(UnauthorizedException ex){
            return Unauthorized(ex.Message);
        }
        catch(NotFoundException ex){
            return NotFound(ex.Message);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
}