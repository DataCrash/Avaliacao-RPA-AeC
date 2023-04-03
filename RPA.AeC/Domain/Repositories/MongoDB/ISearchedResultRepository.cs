using RPA.AeC.Domain.Entities;

namespace RPA.AeC.Domain.Repositories.MongoDB
{
    public interface ISearchedResultRepository
    {
        Task Delete(string term);
        Task Insert(List<SearchedResult> searchedResults);
        Task<List<SearchedResult>> GetByTerm(string term);
    }
}
