using RPA.AeC.Domain.Entities;
using RPA.AeC.Domain.Repositories.MongoDB;
using RPA.AeC.Services.RPA;

namespace RPA.AeC.Application.UseCases.GetSearchedResultUseCase
{
    public class GetSearchedResultUseCase : IGetSearchedResultUseCase
    {
        private readonly ISearchedResultRepository _repository;
        private readonly ISearchAutomationService _searchAutomation;

        public GetSearchedResultUseCase(ISearchedResultRepository repository,
                                        ISearchAutomationService searchAutomation)
        {
            _repository = repository;
            _searchAutomation = searchAutomation;
        }

        public List<SearchedResult> Execute(string term)
        {
            var searchedResults = _searchAutomation.Search(term);

            if (searchedResults.Count > 0)
            {
                _repository.Delete(term);
                _repository.Insert(searchedResults);
            }

            return _repository.GetByTerm(term);
        }
    }
}