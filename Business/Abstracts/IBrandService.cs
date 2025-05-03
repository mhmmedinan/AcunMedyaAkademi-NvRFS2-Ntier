using Business.Dtos.Requests.Brands;
using Business.Dtos.Responses.Brands;
using Entities;

namespace Business.Abstracts;

public interface IBrandService
{
    //void Add(Brand brand);
    //List<Brand> GetAll();


    //REquest-Response Pattern
    CreatedBrandResponse Add(CreateBrandRequest request);
    List<GetListBrandResponse> GetList();
}
