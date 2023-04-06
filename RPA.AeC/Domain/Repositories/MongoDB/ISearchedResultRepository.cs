using RPA.AeC.Domain.Entities;

namespace RPA.AeC.Domain.Repositories.MongoDB
{
    public interface ISearchedResultRepository
    {
        void Delete(string term);

        void Insert(List<SearchedResult> searchedResults);

        List<SearchedResult> GetByTerm(string term);
    }
}