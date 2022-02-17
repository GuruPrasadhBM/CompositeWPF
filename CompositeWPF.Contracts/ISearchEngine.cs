namespace CompositeWPF.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Contract for Search Engine Service
    /// </summary>
    public interface ISearchEngine
    {
        /// <summary>
        /// Fetch Search results
        /// </summary>
        /// <param name="keywords">search keyword</param>
        /// <returns>List of websites from search results as a list of strings</returns>
        IEnumerable<string> FetchSearchResults(string keywords);

        /// <summary>
        /// Fetch Search results, filter based on url and return the position of occurance as array
        /// </summary>
        /// <param name="keywords">search keyword</param>
        /// <param name="searchUrl">url to be matched</param>
        /// <returns>url occurance index/position</returns>
        IEnumerable<int> FetchAndFilterSearchResults(string keywords, string searchUrl);
    }
}
