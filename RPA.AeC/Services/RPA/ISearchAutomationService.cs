using RPA.AeC.Domain.Entities;

namespace RPA.AeC.Services.RPA
{
    public interface ISearchAutomationService
    {
        List<SearchedResult> Search(string searchText);
    }
}