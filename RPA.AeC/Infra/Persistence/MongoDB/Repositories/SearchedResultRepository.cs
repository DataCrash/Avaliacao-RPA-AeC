using MongoDB.Driver;
using RPA.AeC.API.Infra.Persistence.MongoDB.DBContext;
using RPA.AeC.Domain.Entities;
using RPA.AeC.Domain.Repositories.MongoDB;

namespace RPA.AeC.Infra.Persistence.MongoDB.Repositories
{
    public class SearchedResultRepository : ISearchedResultRepository
    {
        private readonly MongoDBContext _context;

        public SearchedResultRepository()
        {
            _context = new MongoDBContext();
        }

        public void Delete(string term) =>
            _context.SearchedResult.DeleteMany(x => x.SearchTerm == term);

        public void Insert(List<SearchedResult> searchedResults) =>
                _context.SearchedResult.InsertMany(searchedResults);

        public List<SearchedResult> GetByTerm(string term) =>
            _context.SearchedResult.Find(x => x.SearchTerm == term).ToList();
    }
}