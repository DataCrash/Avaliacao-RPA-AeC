using RPA.AeC.Application.UseCases.GetSearchedResultUseCase;
using RPA.AeC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RPA.AeC.API.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchedResultController : ControllerBase
    {
        private readonly IGetSearchedResultUseCase _getSearchedResultUseCase;

        public SearchedResultController(IGetSearchedResultUseCase getSearchedResultUseCase)
        {
            _getSearchedResultUseCase = getSearchedResultUseCase;
        }

        [HttpGet("{term}")]
        public Task<List<SearchedResult>> Get(string term) => _getSearchedResultUseCase.Execute(term);
    }
}
