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
        //private ObservableCollection<ViewModelBase> _viewModels =
        //    new ObservableCollection<ViewModelBase>();
        private List<string> _viewModelHistory = new List<string>();

        private RelayCommand _backCommand;
        private NavigationMap _navigationMap;

        public NavigationProvider()
        {
            _backCommand = new RelayCommand(GoBackward);
            _backCommand.SetCanExecute(false);
        }

        public void BuildNavigationMap()
        {
            _navigationMap = NavigationConfig.BuildNavigationMap();
        }

        public ICommand Back
        {
            get { return _backCommand; }
        }

        public string Title
        {
            get {
                if (_currentContents == null) return "";
                return _currentContents.Title; 
            }
        }

        private ViewModelBase _currentContents;
        public ViewModelBase CurrentContents
        {
            get { return _currentContents; }
            set
            {
                if (value != _currentContents)
                {
                    _currentContents = value;
                    NotifyPropertyChanged("CurrentContents");
                    NotifyPropertyChanged("Title");
                }
            }
        }

        //public void GoForward(ViewModelBase viewModel)
        //{
        //    _viewModels.Add(viewModel);
        //    _backCommand.SetCanExecute(true);
        //    NotifyPropertyChanged("Title");
        //    NotifyPropertyChanged("CurrentContents");
        //}

        public void Navigate(string actionName, params object[] actionParameters)
        {
            var sourceTypeName = CurrentContents == null?"": CurrentContents.GetType().Name;

            var viewModel = _navigationMap.GetDestinationViewModel(sourceTypeName, actionName, actionParameters);
            _viewModelHistory.Add(viewModel.GetType().Name);
            _backCommand.SetCanExecute(true);

            CurrentContents = viewModel;
        }

        //public void GoBackward()
        //{
        //    _viewModels.RemoveAt(_viewModels.Count - 1);
        //    if (_viewModels.Count == 1)
        //        _backCommand.SetCanExecute(false);
        //    NotifyPropertyChanged("Title");
        //    NotifyPropertyChanged("CurrentContents");
        //}

        public void GoBackward()
        {
            var sourceTypeName = CurrentContents == null ? "" : CurrentContents.GetType().Name;

            _viewModelHistory.RemoveAt(_viewModelHistory.Count - 1);
            if (_viewModelHistory.Count == 1)
                _backCommand.SetCanExecute(false);

            var viewModel = _navigationMap.GetDestinationViewModel(sourceTypeName, "back", null /*actionParameters*/);
            CurrentContents = viewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
