namespace CompositeWPF.ViewModels
{
    using CompositeWPF.Contracts;
    using CompositeWPF.Utilities;

    /// <summary>
    /// Shell - MainWindow View Model 
    /// This holds many regions where individual views can be loaded
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private ResultsViewModel resultsViewModel;
        private IDataManager dataManager;

        /// <summary>
        /// Child View Model Instance        
        /// </summary>
        public ResultsViewModel ResultsViewModel
        {
            get
            {
                if (this.resultsViewModel == null)
                {
                    this.resultsViewModel = new ResultsViewModel(dataManager);
                }

                return this.resultsViewModel;
            }
        }

        /// <summary>
        /// MainWindowViewModel 
        /// </summary>
        /// <param name="dataManager">Model Injected</param>
        public MainWindowViewModel(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }
    }
}
