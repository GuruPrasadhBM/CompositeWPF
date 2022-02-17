namespace CompositeWPF.Models
{
    using CompositeWPF.Contracts;
    using System.Collections.Generic;

    /// <summary>
    /// Model
    /// </summary>
    public class DataManager : IDataManager
    {
        private ISearchEngine searchEngine;

        /// <summary>
        /// Data Manager - Model
        /// </summary>
        /// <param name="searchEngine">Constructor injected search engine</param>
        public DataManager(ISearchEngine searchEngine)
        {
            this.searchEngine = searchEngine;
        }

        /// <summary>
        /// Fetch Search results, filter based on url and return the position of occurance as array
        /// </summary>
        /// <param name="keywords">Search keywords</param>
        /// <param name="url">url to be matched</param>
        /// <returns>url occurance index/position</returns>
        IEnumerable<int> IDataManager.FetchResults(string keywords, string url)
        {
            return searchEngine?.FetchAndFilterSearchResults(keywords, url);
        }
    }
}
