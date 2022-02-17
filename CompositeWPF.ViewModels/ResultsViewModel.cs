namespace CompositeWPF.ViewModels
{
    using CompositeWPF.Contracts;
    using CompositeWPF.Utilities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    public class ResultsViewModel : ViewModelBase
    {
        IDataManager dataManager;
        private string searchResult;
        private readonly string searchUrl = "www.smokeball.com.au";
        private readonly string keywords = "conveyancing software";

        /// <summary>
        /// To Control the Enable state of button - Otherwise Command.InvalidateCanExecute(); has to be explicitly called
        /// </summary>
        private bool isSearchEnabled = true;
        public bool IsSearchEnabled
        {
            get
            {
                return isSearchEnabled;
            }
            set
            {
                isSearchEnabled = value; 
                OnPropertyChanged("IsSearchEnabled");
            }
        }

        /// <summary>
        /// Results View Model
        /// </summary>
        /// <param name="dataManager">Constructor Injected Model/DataManager</param>
        public ResultsViewModel(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        /// <summary>
        /// Search result and status to display in UI
        /// </summary>
        public string SearchResult
        {
            get
            {
                return searchResult;
            }
            set
            {
                searchResult = value;
                OnPropertyChanged("SearchResult");
            }
        }

        /// <summary>
        /// Get Results Command
        /// </summary>
        public ICommand GetResultsCommand
        {
            get
            {
                return new RelayCommand(cmd => this.GetResultsCommandHandler());
            }
        }

        /// <summary>
        /// Handler for Get Results Command
        /// </summary>
        private void GetResultsCommandHandler()
        {
            Task task = Task.Run(() => GetResults());
        }

        /// <summary>
        /// Get results
        /// </summary>
        private void GetResults()
        {
            SearchResult = "Please wait.. your query is being processed..";
            IsSearchEnabled = false;
            var result = dataManager.FetchResults(keywords, searchUrl);
            IsSearchEnabled = true;

            if (result != null)
            {
                int firstOccuranceIndex = result.FirstOrDefault<int>();

                if (firstOccuranceIndex == 0)
                {
                    SearchResult = string.Format("Sorry!! {0} is not available on the search results", searchUrl);
                    return;
                }


                if (firstOccuranceIndex > 100)
                {
                    SearchResult = string.Format("{0} is available, but it is beyond top 100 results, we need to focus on improving our marketing strategies..", searchUrl);
                    return;
                }

                string csvResult = String.Join(", ", result.Select(x => x.ToString()).ToArray());
                SearchResult = string.Format("Congratulations!! {0} is available in the following position(s) : {1}", searchUrl, csvResult);
                return;
            }
            else
            {
                SearchResult = string.Format("Sorry!!, There is a problem in fetching results, please try after sometime");
                return;
            }
        }
    }
}