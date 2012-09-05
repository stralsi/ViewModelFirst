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
        private RelayCommand _backCommand;

        public NavigationProvider(Context context)
        {
            _contents.Add(new MainMenuViewModel(context, this));

            _backCommand = new RelayCommand(delegate
            {
                GoBackward();
            });
        }

        public ICommand Back
        {
            get { return _backCommand; }
        }

        public IEnumerable<ViewModelBase> Contents
        {
            get { return _contents; }
        }

        public void GoForward(ViewModelBase viewModel)
        {
            _contents.Add(viewModel);
        }

        public void GoBackward()
        {
            _contents.RemoveAt(_contents.Count - 1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
