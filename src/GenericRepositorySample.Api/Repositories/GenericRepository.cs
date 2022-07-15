using Microsoft.EntityFrameworkCore;
using GenericRepositorySample.Api.DataContexts;
using GenericRepositorySample.Api.Repositories.Interfaces;

namespace GenericRepositorySample.Api.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DataContext _dataContext;
        private DbSet<T> _table;

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _table = _dataContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetById(long id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Add(T t)
        {
            await _table.AddAsync(t);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Edit(T t)
        {
            _dataContext.Entry(t).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            T obj = await _table.FindAsync(id);

            if (obj != null)
            {
                _table.Remove(obj);
                _dataContext.SaveChanges();
            }
        }
    }
}
