using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Models;
using Gantt_Chart_Backend.Exceptions;
using Gantt_Chart_Backend.Repositories.Interfaces;
using Gantt_Chart_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gantt_Chart_Backend.Services.Implementations;

public class UsersService : IUsersService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly GanttPlatformDbContext _dbcontext;
    private readonly IJwtProvider _jwtProvider;

    public UsersService (
        IPasswordHasher passwordHasher, 
        GanttPlatformDbContext dbcontext,
        IJwtProvider jwtProvider
        )
    {
        _passwordHasher = passwordHasher;
        _dbcontext = dbcontext;
        _jwtProvider = jwtProvider;
    }
    
    public async Task<Guid> Register (UserRequestDto userRequestDto)
    {
        var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.Email == userRequestDto.Email);

        if (user is not null)
            throw new UserAlreadyExistsException();
        
        var newUser = new User()
        {
            Id = Guid.NewGuid(),
            NickName = userRequestDto.NickName,
            Email = userRequestDto.Email,
            PasswordHash = _passwordHasher.GeneratePasswordHash(userRequestDto.Password)
        };
        
        _dbcontext.Users.Add(newUser);
        
        await _dbcontext.SaveChangesAsync();
        
        return newUser.Id;
    }

    public async Task<string> Login (UserRequestDto userDto)
    {
        var user = await _dbcontext.Users
            .FirstOrDefaultAsync(u => u.Email == userDto.Email);
        
        if (user is null) throw new ResourceNotFoundException();

        if (!_passwordHasher.VerifyPassword(userDto.Password, user.PasswordHash)) 
            throw new InvalidCredentialsException();
        
        var token = _jwtProvider.GenerateToken(user);

        return token;
    }

    public Task DeleteUser()
    {
        throw new NotImplementedException();
    }

    public Task UpdateUser()
    {
        throw new NotImplementedException();
    }
}