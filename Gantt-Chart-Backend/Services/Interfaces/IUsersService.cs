using Gantt_Chart_Backend.Data.DTOs;

namespace Gantt_Chart_Backend.Services.Interfaces;

public interface IUsersService
{
    public Task<Guid> Register(UserRequestDto userRequestDto);
    public Task<String> Login(LoginUserRequest userRequestDto);
    public Task DeleteUser();
    public Task UpdateUser();

}