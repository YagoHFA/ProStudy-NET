using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase{

    public string Get() => "Hello";
}