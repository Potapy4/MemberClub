using FluentValidation;
using MemberClub.BLL.DTO;
using MemberClub.BLL.Interfaces;
using MemberClub.BLL.Validators;
using MemberClub.DAL;
using MemberClub.DAL.Entities;

namespace MemberClub.BLL.Services;

public class UserService : IUserService
{
    private readonly MemberClubDBContext _context;

    public UserService(MemberClubDBContext context)
    {
        _context = context;
    }

    public void AddUser(UserDto user)
    {
        var validationResult = new UserValidator().Validate(user);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToString());
        }

        if (_context.Users.Any(x => x.Email == user.Email))
        {
            throw new Exception("User with the same email address already exists");
        }

        var userEntity = new User
        {
            Email = user.Email,
            Name = user.Name,
            RegistrationDate = DateTime.UtcNow,
            Id = _context.Users.Max(u => u.Id) + 1
        };

        _context.Users.Add(userEntity);
        _context.SaveChanges();
    }
    
    public IEnumerable<UserDto> GetUsers()
    {
        return _context.Users.Select(u => new UserDto
        {
            Email = u.Email,
            Id = u.Id,
            Name = u.Name,
            RegistrationDate = u.RegistrationDate
        });
    }
}