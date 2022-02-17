namespace CompositeWPF.Shell
{
    using CompositeWPF.Contracts;
    using CompositeWPF.Models;
    using CompositeWPF.Services;
    using CompositeWPF.ViewModels;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Override OnStartup to introduce Object Composition
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ComposeObjects();
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Object Composition for DI
        /// </summary>
        private void ComposeObjects()
        {
            ISearchEngine googleSearchEngine = new GoogleSearch(); 
            //// This can be replaced with another service provider
            //// To use Yahoo engine
            //// ISearchEngine yahooSearchEngine = new YahooSearch();

            IDataManager dataManager = new DataManager(googleSearchEngine);
            Application.Current.MainWindow = new MainWindow();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(dataManager);

            Application.Current.MainWindow.DataContext = mainWindowViewModel;
        }
    }
}
