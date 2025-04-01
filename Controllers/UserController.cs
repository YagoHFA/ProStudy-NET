using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase{

    [HttpGet]
    public string Get() => "Hello";
}