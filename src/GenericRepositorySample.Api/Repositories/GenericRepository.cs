using Microsoft.EntityFrameworkCore;
using GenericRepositorySample.Api.DataContexts;
using GenericRepositorySample.Api.Repositories.Interfaces;

namespace GenericRepositorySample.Api.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DataContext DataContext { get; }
        public DbSet<T> Table { get; }

        public GenericRepository(DataContext dataContext)
        {
            DataContext = dataContext;
            Table = DataContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetById(long id)
        {
            return await Table.FindAsync(id);
        }

        public async Task Add(T t)
        {
            await Table.AddAsync(t);
            await DataContext.SaveChangesAsync();
        }

        public async Task Edit(T t)
        {
            DataContext.Entry(t).State = EntityState.Modified;
            await DataContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            T obj = await Table.FindAsync(id);

            if (obj != null)
            {
                Table.Remove(obj);
                DataContext.SaveChanges();
            }
        }
    }
}
