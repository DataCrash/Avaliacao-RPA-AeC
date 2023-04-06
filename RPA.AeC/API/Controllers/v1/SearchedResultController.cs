using Microsoft.AspNetCore.Mvc;
using RPA.AeC.Application.UseCases.GetSearchedResultUseCase;

namespace RPA.AeC.API.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SearchedResultController : ControllerBase
    {
        private readonly IGetSearchedResultUseCase _getSearchedResultUseCase;

        public SearchedResultController(IGetSearchedResultUseCase getSearchedResultUseCase)
        {
            _getSearchedResultUseCase = getSearchedResultUseCase;
        }

        [HttpGet("{term}")]
        public IActionResult Get(string term) =>
            Ok(_getSearchedResultUseCase.Execute(term));
    }
}