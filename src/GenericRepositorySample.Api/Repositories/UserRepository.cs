using Microsoft.EntityFrameworkCore;
using GenericRepositorySample.Api.DataContexts;
using GenericRepositorySample.Api.Entities;
using GenericRepositorySample.Api.Repositories.Interfaces;

namespace GenericRepositorySample.Api.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext) 
        : base(dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<User> GetByEmail(string email)
    {
        return await _dataContext.Users.SingleOrDefaultAsync(
                                            u => u.Email.ToLower() == email.ToLower());
    }
}
