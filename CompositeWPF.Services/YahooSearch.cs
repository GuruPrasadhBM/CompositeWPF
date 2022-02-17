using CompositeWPF.Contracts;
using System;
using System.Collections.Generic;

namespace CompositeWPF.Services
{
    /// <summary>
    /// Mockup- Not actual implementation
    /// </summary>
    public class YahooSearch : ISearchEngine
    {
        IEnumerable<int> ISearchEngine.FetchAndFilterSearchResults(string keywords, string searchUrl)
        {
            return new List<int>() {1, 19, 25};
        }

        IEnumerable<string> ISearchEngine.FetchSearchResults(string keywords)
        {
            IList<string> searchResults = new List<string>();
            searchResults.Add("www.smokeball.com.au");
            searchResults.Add("www.legal.com");
            searchResults.Add("www.conveyancing.com");
            searchResults.Add("www.smokeball.com.au");
            searchResults.Add("www.lawers.com");
            searchResults.Add("www.google.com");
            searchResults.Add("www.google.com");
            return searchResults;
        }
    }
}
