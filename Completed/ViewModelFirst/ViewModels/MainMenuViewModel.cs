using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModelFirst.Models;

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
    }
}
