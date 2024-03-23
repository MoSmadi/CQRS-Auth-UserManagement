using BaseUserManagement.Infrastructure.Users.Models;
using Riok.Mapperly.Abstractions;

namespace BaseUserManagement.Infrastructure.Users.Mappers;

[Mapper]
public partial class UserMapper
{
    public partial BaseUserManagement.Domain.Users.Models.User ToDomainModel(UserDb userDb);
}