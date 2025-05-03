using AutoMapper;
using Business.Dtos.Requests.Models;
using Business.Dtos.Responses.Models;
using Entities;

namespace Business.Profiles.Models;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, CreateModelRequest>().ReverseMap();
        CreateMap<Model, CreatedModelResponse>().ReverseMap();
        CreateMap<Model, GetListModelResponse>().ReverseMap();
    }
}
