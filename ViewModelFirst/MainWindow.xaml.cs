using System.Windows;
using ViewModelFirst.Models;
using ViewModelFirst.ViewModels;
using ViewModelFirst.Views;

namespace ViewModelFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var context = new Context();

            NavigationProvider navigationProvider = null;
            NavigationMap navigationMap = new NavigationMap();

            navigationMap.RegisterNavigation("", "initialScreen", (actionParameters) => new MainMenuViewModel(context, navigationProvider));

            navigationMap.RegisterNavigation("MainMenuViewModel", "players", (actionParameters)=>new PlayersViewModel(context,navigationProvider));

            navigationMap.RegisterNavigation("PlayersViewModel", "details", (actionParameters) =>new PlayerViewModel((Player)actionParameters[0]));

            navigationMap.RegisterNavigation("PlayerViewModel", "back", (actionParameters) => new PlayersViewModel(context, navigationProvider));

            navigationMap.RegisterNavigation("PlayersViewModel", "back", (actionParameters) => new MainMenuViewModel(context, navigationProvider));

            navigationMap.RegisterNavigation("MainMenuViewModel", "games", (actionParameters) => new GamesViewModel());

            navigationMap.RegisterNavigation("GamesViewModel", "back", (actionParameters) => new MainMenuViewModel(context, navigationProvider));

            navigationMap.RegisterNavigation("MainMenuViewModel", "teams", (actionParameters) => new TeamsViewModel());

            navigationMap.RegisterNavigation("TeamsViewModel", "back", (actionParameters) => new MainMenuViewModel(context, navigationProvider));

            navigationProvider = new NavigationProvider(navigationMap,context);

            navigationProvider.Navigate("initialScreen");

            DataContext = navigationProvider;
        }
    }
}
