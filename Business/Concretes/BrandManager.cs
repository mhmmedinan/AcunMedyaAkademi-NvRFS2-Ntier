using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Brands;
using Business.Dtos.Responses.Brands;
using Entities;
using Repositories.Abstracts;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public BrandManager(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public CreatedBrandResponse Add(CreateBrandRequest request)
    {
        //ManualMapping
        //Brand brand = new Brand
        //{
        //    Name = request.Name,
        //};
        //Brand addedBrand = _brandRepository.Add(brand);

        //return new CreatedBrandResponse
        //{
        //    Id = addedBrand.Id,
        //    Name = addedBrand.Name,
        //    CreatedDate = addedBrand.CreatedDate,
        //};


        //AutoMapper

        Brand brand = _mapper.Map<Brand>(request);
        Brand createdBrand = _brandRepository.Add(brand);
        CreatedBrandResponse response = _mapper.Map<CreatedBrandResponse>(createdBrand);
        return response;
    }

    public List<GetListBrandResponse> GetList()
    {
        //ManualMapping
        //List<Brand> brands = _brandRepository.GetAll();
        //List<GetListBrandResponse> responses = new List<GetListBrandResponse>();

        //foreach (var brand in brands)
        //{
        //    responses.Add(new GetListBrandResponse
        //    {
        //        Id = brand.Id,
        //        Name = brand.Name,
        //        CreatedDate = brand.CreatedDate,
        //        UpdatedDate = brand.UpdatedDate,
        //    });
        //}
        //return responses;


        //AutoMapper
        List<Brand> brands = _brandRepository.GetAll();
        List<GetListBrandResponse> responses = _mapper.Map<List<GetListBrandResponse>>(brands);
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
