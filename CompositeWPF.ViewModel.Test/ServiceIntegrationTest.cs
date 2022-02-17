namespace CompositeWPF.Test
{
    using CompositeWPF.Contracts;
    using CompositeWPF.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ServiceIntegrationTest
    {
        [TestMethod]
        public void GoogleService_Test_FetchSearchResults()
        {
            string keyword = "conveyancing software";
            ISearchEngine searchEngine = new GoogleSearch();
            IEnumerable<string> searchResults = searchEngine.FetchSearchResults(keyword);
            Assert.IsNotNull(searchResults);
        }

        [TestMethod]
        public void GoogleService_FetchSearchResults_ArgumentsTest()
        {
            ISearchEngine searchEngine = new GoogleSearch();
            IEnumerable<string> searchResults = searchEngine.FetchSearchResults(null);
            Assert.IsNull(searchResults);
        }

        [TestMethod]
        public void GoogleService_Test_FetchAndFilterSearchResults()
        {
            string keyword = "conveyancing software";
            string url = "www.smokeball.com.au";
            ISearchEngine searchEngine = new GoogleSearch();
            IEnumerable<int> searchResults = searchEngine.FetchAndFilterSearchResults(keyword, url);
            Assert.IsNotNull(searchResults);
        }

        [TestMethod]
        public void GoogleService_Test_FetchAndFilterSearchResults_ArgumentsTest()
        {
            ISearchEngine searchEngine = new GoogleSearch();
            IEnumerable<int> searchResults = searchEngine.FetchAndFilterSearchResults(null, null);
            Assert.IsNull(searchResults);
        }
    }
}
