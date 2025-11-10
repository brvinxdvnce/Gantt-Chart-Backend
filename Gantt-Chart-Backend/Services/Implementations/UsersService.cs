using Gantt_Chart_Backend.Repositories.Interfaces;
using Gantt_Chart_Backend.Services.Interfaces;

namespace Gantt_Chart_Backend.Services.Implementations;

public class UsersService : IUsersService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;

    public UsersService (IPasswordHasher passwordHasher, IUserRepository userRepository)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
    }
    
    public async Task Register (string nickName, string email, string password)
    {
        var hashedPassword = _passwordHasher.GeneratePasswordHash(password);
        
    }

    public async Task Login (string email, string password)
    {
        
    }
}