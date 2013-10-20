using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModelFirst.Models;
using ViewModelFirst.ViewModels;

namespace ViewModelFirst
{
    public class NavigationConfig
    {
        public static NavigationMap BuildNavigationMap()
        {
            NavigationMap navigationMap = new NavigationMap();

            navigationMap.RegisterNavigation("", "initialScreen", ObjBuilder.BuildMainMenuViewModel);

            navigationMap.RegisterNavigation("MainMenuViewModel", "players", ObjBuilder.BuildPlayersViewModel);

            navigationMap.RegisterNavigation("PlayersViewModel", "details", ObjBuilder.BuildPlayerViewModel);

            navigationMap.RegisterNavigation("PlayerViewModel", "back", ObjBuilder.BuildPlayersViewModel);

            navigationMap.RegisterNavigation("PlayersViewModel", "back", ObjBuilder.BuildMainMenuViewModel);

            navigationMap.RegisterNavigation("MainMenuViewModel", "games", ObjBuilder.BuildGamesViewModel);

            navigationMap.RegisterNavigation("GamesViewModel", "back", ObjBuilder.BuildMainMenuViewModel);

            navigationMap.RegisterNavigation("MainMenuViewModel", "teams", ObjBuilder.BuildTeamsViewModel);

            navigationMap.RegisterNavigation("TeamsViewModel", "back", ObjBuilder.BuildMainMenuViewModel);

            return navigationMap;
        }
    }
}
