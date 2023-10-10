namespace ShopABC.Interfaces
{
    public interface IGenericRespository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
    }
}
