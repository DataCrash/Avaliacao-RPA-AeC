using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RPA.AeC.Domain.Entities;

namespace RPA.AeC.Services.RPA
{
    public class SearchAutomationService : ISearchAutomationService
    { 
        public List<SearchedResult> Search(string searchText)
        {
            var _webDriver = new ChromeDriver();

            _webDriver.Navigate().GoToUrl("https://www.aec.com.br/");
            _webDriver.Manage().Window.Maximize();
            _webDriver.FindElement(By.ClassName("buscar")).Click();
            _webDriver.FindElement(By.Name("s")).SendKeys(searchText);
            _webDriver.FindElement(By.TagName("form")).FindElement(By.TagName("button")).Click();

            var resultList = new List<SearchedResult>();

            string nextPage;
            do
            {
                nextPage = _webDriver.FindElement(By.ClassName("ver-mais")).Text;
                var searchList = _webDriver.FindElements(By.ClassName("cardPost"));

                foreach (var item in searchList)
                {
                    var title = item.FindElement(By.ClassName("tres-linhas")).Text;
                    var area = item.FindElement(By.ClassName("hat")).Text;
                    var description = item.FindElement(By.ClassName("duas-linhas")).Text;

                    var small = item.FindElement(By.TagName("small")).Text;
                    var autSplitter = small.IndexOf(" por ");
                    var pubSplitter = small.IndexOf(" em ");

                    var author = small.Substring(autSplitter + 5, pubSplitter - autSplitter - 5);
                    var publishDate = small.Substring(pubSplitter + 4, small.Length - pubSplitter - 4);

                    var model = new SearchedResult()
                    {
                        Title = title,
                        Area = area,
                        Description = description,
                        Author = author,
                        PublishDate = Convert.ToDateTime(publishDate),
                        SeachDate = DateTime.UtcNow,
                        SearchTerm = searchText
                    };

                    resultList.Add(model);
                }

                if (nextPage != string.Empty)
                {
                    var url = _webDriver.FindElement(By.ClassName("ver-mais")).FindElement(By.TagName("a")).GetAttribute("href");
                    _webDriver.Navigate().GoToUrl(url);
                }

            } while (nextPage != string.Empty);

            _webDriver.Dispose();

            return resultList;
        }
    }
}