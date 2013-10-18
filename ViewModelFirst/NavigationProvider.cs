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
        private ObservableCollection<ViewModelBase> _viewModels =
            new ObservableCollection<ViewModelBase>();
        private RelayCommand _backCommand;

        public NavigationProvider(Context context)
        {
            _viewModels.Add(new MainMenuViewModel(context, this));
            _backCommand = new RelayCommand(GoBackward);
            _backCommand.SetCanExecute(false);
        }

        public ICommand Back
        {
            get { return _backCommand; }
        }

        public string Title
        {
            get { return _viewModels.Last().Title; }
        }

        public ViewModelBase CurrentContents
        {
            get { return _viewModels.LastOrDefault(); }
        }

        public void GoForward(ViewModelBase viewModel)
        {
            _viewModels.Add(viewModel);
            _backCommand.SetCanExecute(true);
            NotifyPropertyChanged("Title");
            NotifyPropertyChanged("CurrentContents");
        }

        public void GoBackward()
        {
            _viewModels.RemoveAt(_viewModels.Count - 1);
            if (_viewModels.Count == 1)
                _backCommand.SetCanExecute(false);
            NotifyPropertyChanged("Title");
            NotifyPropertyChanged("CurrentContents");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
