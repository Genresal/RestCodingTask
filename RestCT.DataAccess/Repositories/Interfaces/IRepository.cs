using RestCT.Shared.Models;

namespace RestCT.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        Task Create(T request);
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task Update(T request);
        Task Delete(int id);
    }
}
