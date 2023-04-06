using RPA.AeC.Domain.Entities;

namespace RPA.AeC.Application.UseCases.GetSearchedResultUseCase
{
    public interface IGetSearchedResultUseCase
    {
        List<SearchedResult> Execute(string term);
    }
}