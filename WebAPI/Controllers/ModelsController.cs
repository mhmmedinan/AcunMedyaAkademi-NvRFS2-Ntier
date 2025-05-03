using Business.Abstracts;
using Business.Dtos.Requests.Models;
using Business.Dtos.Responses.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }


        [HttpPost]
        public ActionResult<CreatedModelResponse> Add([FromBody] CreateModelRequest request)
        {
            return Created("", _modelService.Add(request));
        }

        [HttpGet]
        public ActionResult<List<GetListModelResponse>> GetList()
        {
            return Ok(_modelService.GetList());
        }
    }
}
