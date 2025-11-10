using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.Models;
using Gantt_Chart_Backend.Repositories.Interfaces;

namespace Gantt_Chart_Backend.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly GanttPlatformDbContext _dbContext;
    
    public UserRepository(GanttPlatformDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddUser(User user)
    {
        
    }

    public async Task<User> GetUserByEmail(string email)
    {
        throw new InvalidOperationException();
    }
    
    public async Task DeleteUser()
    {
        
    }
}