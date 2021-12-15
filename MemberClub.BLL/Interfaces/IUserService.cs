using MemberClub.BLL.DTO;

namespace MemberClub.BLL.Interfaces;

public interface IUserService
{
    public void AddUser(UserDto user);
    
    public IEnumerable<UserDto> GetUsers();
}