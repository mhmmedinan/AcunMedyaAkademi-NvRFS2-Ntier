using AutoMapper;
using Business.Dtos.Requests.Brands;
using Business.Dtos.Responses.Brands;
using Entities;

namespace Business.Profiles.Brands;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandRequest>().ReverseMap();
        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        CreateMap<Brand, GetListBrandResponse>().ReverseMap();
    }
}
