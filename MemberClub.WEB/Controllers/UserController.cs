using MemberClub.BLL.DTO;
using MemberClub.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MemberClub.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    public IEnumerable<UserDto> Get()
    {
        return _userService.GetUsers();
    }
    
    [HttpPost]
    public IActionResult Post(UserDto userDto)
    {
        _logger.LogInformation("Trying to add user: {userDto}", userDto);
        _userService.AddUser(userDto);

        return Ok();
    }
}