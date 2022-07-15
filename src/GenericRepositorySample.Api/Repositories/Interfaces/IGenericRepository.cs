using GenericRepositorySample.Api.DataContexts;

namespace GenericRepositorySample.Api.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T t);
        Task Delete(long id);
        Task Edit(T t);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long id);
    }
}