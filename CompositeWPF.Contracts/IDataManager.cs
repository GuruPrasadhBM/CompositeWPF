namespace CompositeWPF.Contracts
{
    using System.Collections.Generic;    
    public interface IDataManager
    {
        /// <summary>
        /// Fetch Search results, filter based on url and return the position of occurance as array
        /// </summary>
        /// <param name="keywords">Search keywords</param>
        /// <param name="url">url to be matched</param>
        /// <returns>url occurance index/position</returns>
        IEnumerable<int> FetchResults(string keywords, string url);
    }
}
