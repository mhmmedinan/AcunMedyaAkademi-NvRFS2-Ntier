using Business.Abstracts;
using Business.Dtos.Requests.Brand;
using Business.Dtos.Responses.Brand;
using Entities;
using Repositories.Abstracts;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandManager(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public CreatedBrandResponse Add(CreateBrandRequest request)
    {
        //ManualMapping
        Brand brand = new Brand
        {
            Name = request.Name,
        };
        Brand addedBrand = _brandRepository.Add(brand);

        return new CreatedBrandResponse
        {
            Id = addedBrand.Id,
            Name = addedBrand.Name,
            CreatedDate = addedBrand.CreatedDate,
        };
    }

    public List<GetListBrandResponse> GetList()
    {
        //ManualMapping
        List<Brand> brands = _brandRepository.GetAll();
        List<GetListBrandResponse> responses = new List<GetListBrandResponse>();

        foreach (var brand in brands)
        {
            responses.Add(new GetListBrandResponse
            {
                Id = brand.Id,
                Name = brand.Name,
                CreatedDate = brand.CreatedDate,
                UpdatedDate = brand.UpdatedDate,
            });
        }
        return responses;
    }

    //public void Add(Brand brand)
    //{
    //    _brandRepository.Add(brand);
    //}

    //public List<Brand> GetAll()
    //{
    //    return _brandRepository.GetAll();
    //}
}
