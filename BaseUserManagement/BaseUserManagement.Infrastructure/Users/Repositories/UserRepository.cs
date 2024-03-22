using BaseUserManagement.Domain.Users.Models;
using BaseUserManagement.Domain.Users.Repositories;
using BaseUserManagement.Infrastructure.Users.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BaseUserManagement.Infrastructure.Users.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BaseDbContext _dbContext;
    private readonly UserMapper _userMapper;

    public UserRepository(BaseDbContext dbContext, UserMapper userMapper)
    {
        _dbContext = dbContext;
        _userMapper = userMapper;
    }

    public async Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var user = await _dbContext.User
            .FirstOrDefaultAsync(u => u.Username == username, cancellationToken);

        return user == null ? null : _userMapper.ToDomainModel(user);
    }
    
    public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _dbContext.User
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

        return user == null ? null : _userMapper.ToDomainModel(user);
    }
}