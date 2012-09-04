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
        private ObservableCollection<ViewModelBase> _contents =
            new ObservableCollection<ViewModelBase>();

        public NavigationProvider(Context context)
        {
            _contents.Add(new MainMenuViewModel(context, this));
        }

        public IEnumerable<ViewModelBase> Contents
        {
            get { return _contents; }
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
