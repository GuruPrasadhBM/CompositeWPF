namespace CompositeWPF.Utilities
{
    using System.ComponentModel;

    /// <summary>
    /// Base class implmentation for INotifyPropertyChanged Support
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
