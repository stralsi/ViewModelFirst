using System.Collections.ObjectModel;
using ViewModelFirst.Models;
using ViewModelFirst.ViewModels;
using System.Collections.Generic;

namespace ViewModelFirst
{
    public class NavigationProvider : INavigationProvider
    {
        private ObservableCollection<ViewModelBase> _viewModels =
            new ObservableCollection<ViewModelBase>();

        public NavigationProvider(Document document)
        {
            _viewModels.Add(new MainMenuViewModel(document, this));
        }

        public IEnumerable<ViewModelBase> Contents
        {
            get { return _viewModels; }
        }

        public void GoForward(ViewModelBase viewModel)
        {
            _viewModels.Add(viewModel);
        }

        public void GoBackward()
        {
            _viewModels.RemoveAt(_viewModels.Count - 1);
        }
    }
}
