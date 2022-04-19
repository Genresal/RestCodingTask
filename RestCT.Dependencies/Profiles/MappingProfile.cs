using RestCT.Shared.Models;
using RestCT.Shared.Requests;
using RestCT.Shared.Responses;

namespace SPWB.SportService.BFF.Profiles
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap();
        }

        private void CreateMap()
        {
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<Category, GetCategoryResponse>();
            CreateMap<CreateItemRequest, Item>();
            CreateMap<Item, GetItemResponse>();
        }
    }
}
