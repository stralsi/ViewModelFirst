using System.Windows.Input;
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

        public override string Title
        {
            get { return "Main Menu"; }
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

        public ICommand Teams
        {
            get
            {
                return new RelayCommand(delegate
                {
                    _navigationProvider.GoForward(new TeamsViewModel());
                });
            }
        }

        public ICommand Games
        {
            get
            {
                return new RelayCommand(delegate
                {
                    _navigationProvider.GoForward(new GamesViewModel());
                });
            }
        }
    }
}
