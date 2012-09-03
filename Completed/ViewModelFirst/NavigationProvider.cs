using System.Collections.ObjectModel;
using ViewModelFirst.Models;
using ViewModelFirst.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace ViewModelFirst
{
    public class NavigationProvider : INavigationProvider
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

        public IEnumerable<ViewModelBase> Contents
        {
            get { return _viewModels; }
        }

        public void GoForward(ViewModelBase viewModel)
        {
            _viewModels.Add(viewModel);
            _backCommand.SetCanExecute(true);
        }

        public void GoBackward()
        {
            _viewModels.RemoveAt(_viewModels.Count - 1);
            if (_viewModels.Count == 1)
                _backCommand.SetCanExecute(false);
        }
    }
}
