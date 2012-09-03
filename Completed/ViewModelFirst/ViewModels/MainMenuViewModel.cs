using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModelFirst.Models;
using System.Windows.Input;

namespace ViewModelFirst.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        private readonly Context _context;
        private readonly INavigationProvider _navigationProvider;
        
        public MainMenuViewModel(Context context, INavigationProvider navigationProvider)
        {
            _context = context;
            _navigationProvider = navigationProvider;
        }

        public ICommand Players
        {
            get
            {
                return new RelayCommand(delegate
                {
                    _navigationProvider.GoForward(new PlayersViewModel());
                });
            }
        }
    }
}
