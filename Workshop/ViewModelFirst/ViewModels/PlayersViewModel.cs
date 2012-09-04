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
        
        public PlayersViewModel(Context context, INavigationProvider navigationProvider)
        {
            _context = context;
            _navigationProvider = navigationProvider;
        }

        public override string Title
        {
            get { return "Players"; }
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
            }
        }
    }
}
