using GenericRepositorySample.Api.Entities;

namespace GenericRepositorySample.Api.Repositories.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User> GetByEmail(string email);
}
