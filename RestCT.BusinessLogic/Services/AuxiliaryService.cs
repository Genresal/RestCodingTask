using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.DataAccess.Repositories.Interfaces;

namespace RestCT.DataAccess.Repositories
{
    public class AuxiliaryService : IAuxiliaryService
    {
        private readonly IAuxiliaryRepository _auxiliaryRepository;

        public AuxiliaryService(IAuxiliaryRepository auxiliaryRepository)
        {
            _auxiliaryRepository = auxiliaryRepository;
        }

        public async Task AddDefaultData()
        {
            await _auxiliaryRepository.AddDefaultData();
        }

        public void Clear()
        {
            _auxiliaryRepository.Clear();
        }
    }
}
