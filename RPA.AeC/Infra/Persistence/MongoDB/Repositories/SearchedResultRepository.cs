using RPA.AeC.Domain.Entities;
using RPA.AeC.Domain.Repositories.MongoDB;
using MongoDB.Driver;
using RPA.AeC.API.Infra.Persistence.MongoDB.DBContext;

namespace RPA.AeC.Infra.Persistence.MongoDB.Repositories
{
    public class SearchedResultRepository : ISearchedResultRepository
    {
        private readonly MongoDBContext _context;

        public SearchedResultRepository()
        {
            _context = new MongoDBContext();
        }

        public Task Delete(string term) => 
            _context.SearchedResult.DeleteManyAsync(x => x.SearchTerm == term);

        public Task Insert(List<SearchedResult> searchedResults) =>
                _context.SearchedResult.InsertManyAsync(searchedResults);

        public async Task<List<SearchedResult>> GetByTerm(string term) => 
            await _context.SearchedResult.Find(x => x.SearchTerm == term).ToListAsync();

    }
}
