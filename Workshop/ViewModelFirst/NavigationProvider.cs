using System.Collections.ObjectModel;
using ViewModelFirst.Models;
using ViewModelFirst.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using System.ComponentModel;
using System.Linq;

namespace ViewModelFirst
{
    public class NavigationProvider : INavigationProvider, INotifyPropertyChanged
    {
        public NavigationProvider(Context context)
        {
        }

        public void GoForward(ViewModelBase viewModel)
        {
        }

        public void GoBackward()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
