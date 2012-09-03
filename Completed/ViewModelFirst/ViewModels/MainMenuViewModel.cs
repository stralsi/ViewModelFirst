using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModelFirst.Models;

namespace ViewModelFirst.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        private readonly Document _document;
        private readonly INavigationProvider _navigationProvider;
        
        public MainMenuViewModel(Document document, INavigationProvider navigationProvider)
        {
            _document = document;
            _navigationProvider = navigationProvider;
        }
    }
}
