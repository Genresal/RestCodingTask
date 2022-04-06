using RestCT.Shared.Models;

namespace RestCT.DataAccess.Repositories.Interfaces
{
    public interface IAuxiliaryRepository
    {
        Task AddDefaultData();
        void Clear();
    }
}
