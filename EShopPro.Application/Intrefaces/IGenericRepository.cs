

namespace EShopPro.Application.Intrefaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Entities  { get; }
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(Guid id,T entity);
        Task DeleteAsync(Guid id);
    }
}
