namespace CompositeWPF.Test
{
    using CompositeWPF.Contracts;
    using CompositeWPF.Utilities;
    using CompositeWPF.ViewModel.Test.Mockups;
    using CompositeWPF.ViewModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ResultViewModelTest
    {
        /// <summary>
        /// Test whether DataManager/Model is populating correctly
        /// </summary>
        [TestMethod]
        public void FetchResultsTest()
        {
            IDataManager dataManager = new DataManagerMockup();
            (dataManager as DataManagerMockup).InputFeed = new System.Collections.Generic.List<int>() { 2, 5, 6 };
            ResultsViewModel rvm = new ResultsViewModel(dataManager);
            string expectedString = "Congratulations!! www.smokeball.com.au is available in the following position(s) : 2, 5, 6";
             rvm.CallPrivateMethod("GetResults", null);
            Assert.AreEqual(expectedString, rvm.SearchResult);
        }

        /// <summary>
        /// Test the outcome, if the search url is not in top 100 positions
        /// </summary>
        [TestMethod]
        public void FetchResultsNotOnTop100()
        {
            IDataManager dataManager = new DataManagerMockup();
            (dataManager as DataManagerMockup).InputFeed = new System.Collections.Generic.List<int>() { 101, 111, 112 };
            ResultsViewModel rvm = new ResultsViewModel(dataManager);
            string expectedString = "www.smokeball.com.au is available, but it is beyond top 100 results, we need to focus on improving our marketing strategies..";
            rvm.CallPrivateMethod("GetResults", null);
            Assert.AreEqual(expectedString, rvm.SearchResult);
        }


        /// <summary>
        /// Test the outcome, if the search url is not available in the search results
        /// </summary>
        [TestMethod]
        public void FetchResults_UrlNotAvailable()
        {
            IDataManager dataManager = new DataManagerMockup();
            (dataManager as DataManagerMockup).InputFeed = new System.Collections.Generic.List<int>() { 0 };
            ResultsViewModel rvm = new ResultsViewModel(dataManager);
            string expectedString = "Sorry!! www.smokeball.com.au is not available on the search results";
            rvm.CallPrivateMethod("GetResults", null);
            Assert.AreEqual(expectedString, rvm.SearchResult);
        }

        /// <summary>
        /// Test the outcome, if null parameter is passed or the service failed to return results
        /// </summary>
        [TestMethod]
        public void FetchResults_NullResult()
        {
            IDataManager dataManager = new DataManagerMockup();
            (dataManager as DataManagerMockup).InputFeed = null;
            ResultsViewModel rvm = new ResultsViewModel(dataManager);
            string expectedString = "Sorry!!, There is a problem in fetching results, please try after sometime";
            rvm.CallPrivateMethod("GetResults", null);
            Assert.AreEqual(expectedString, rvm.SearchResult);
        }
    }
}
