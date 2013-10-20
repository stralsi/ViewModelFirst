using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModelFirst.Models;
using System.Windows.Input;

namespace ViewModelFirst.ViewModels
{
    public class PlayersViewModel : ViewModelBase
    {
        private readonly Context _context;
        private readonly INavigationProvider _navigationProvider;

        private string _selectedPlayer;
        private RelayCommand _detailsCommand;
        
        public PlayersViewModel(Context context, INavigationProvider navigationProvider)
        {
            _context = context;
            _navigationProvider = navigationProvider;

            _detailsCommand = new RelayCommand(delegate
            {
                //_navigationProvider.GoForward(new PlayerViewModel(_context.GetPlayer(_selectedPlayer)));
                _navigationProvider.Navigate("details",_context.GetPlayer(_selectedPlayer));
            });
            _detailsCommand.SetCanExecute(false);
        }

        public override string Title
        {
            get { return "Players"; }
        }

        public ICommand Details
        {
            get { return _detailsCommand; }
        }

        public IEnumerable<string> Players
        {
            get
            {
                return
                    from player in _context.Players
                    orderby player.Name
                    select player.Name;
            }
        }

        public string SelectedPlayer
        {
            get { return _selectedPlayer; }
            set
            {
                _selectedPlayer = value;
                _detailsCommand.SetCanExecute
                    (!String.IsNullOrWhiteSpace(_selectedPlayer));
            }
        }
    }
}
