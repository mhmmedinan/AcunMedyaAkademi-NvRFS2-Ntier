using Business.Dtos.Requests.Models;
using Business.Dtos.Responses.Models;

namespace Business.Abstracts;

public interface IModelService
{
    CreatedModelResponse Add(CreateModelRequest request);
    List<GetListModelResponse> GetList();

}
