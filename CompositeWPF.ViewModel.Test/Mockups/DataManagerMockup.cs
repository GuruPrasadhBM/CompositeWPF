namespace CompositeWPF.ViewModel.Test.Mockups
{
    using CompositeWPF.Contracts;
    using System.Collections.Generic;

    /// <summary>
    /// Mockup for Model/DataManager
    /// </summary>
    public class DataManagerMockup : IDataManager
    {
        public DataManagerMockup()
        {
            this.InputFeed = new List<int>() { 2,3,4};
        }

        /// <summary>
        /// Input Feed for results
        /// </summary>
        public List<int> InputFeed { get; set; }

        /// <summary>
        /// Mockup to Fetch Search results, filter based on url and return the position of occurance as array
        /// </summary>
        /// <param name="keywords">Search keywords</param>
        /// <param name="url">url to be matched</param>
        /// <returns>url occurance index/position</returns>
        IEnumerable<int> IDataManager.FetchResults(string keywords, string url)
        {
            return InputFeed;
        }
    }
}
