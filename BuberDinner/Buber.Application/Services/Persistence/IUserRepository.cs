using Buber.Domain.Entities;

namespace Buber.Application.Services.Persistence;

public interface IUserRepository
{
    void Add(User user);
    User? GetUserByEmail(string email);
}