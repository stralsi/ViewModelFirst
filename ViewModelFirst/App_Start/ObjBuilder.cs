using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModelFirst.Models;
using ViewModelFirst.ViewModels;

namespace ViewModelFirst
{
    public class ObjBuilder
    {
        private static Context _context;
        public static Context GetContext()
        {
            if (_context == null)
            {
                _context = new Context();
            }
            return _context;
        }

        private static NavigationProvider _navigationProvider;
        public static NavigationProvider GetNavigationProvider()
        {
            if (_navigationProvider == null)
            {
                _navigationProvider = new NavigationProvider();
                _navigationProvider.BuildNavigationMap();
            }
            return _navigationProvider;
        }

        public static MainMenuViewModel BuildMainMenuViewModel(params object[] parameters)
        {
            return new MainMenuViewModel(GetContext(), GetNavigationProvider());
        }
        public static PlayersViewModel BuildPlayersViewModel(params object[] parameters)
        {
            return new PlayersViewModel(GetContext(), GetNavigationProvider());
        }
        public static PlayerViewModel BuildPlayerViewModel(params object[] parameters)
        {
            return new PlayerViewModel((Player)parameters[0]);
        }
        public static GamesViewModel BuildGamesViewModel(params object[] parameters)
        {
            return new GamesViewModel();
        }
        public static TeamsViewModel BuildTeamsViewModel(params object[] parameters)
        {
            return new TeamsViewModel();
        }
    }
}
