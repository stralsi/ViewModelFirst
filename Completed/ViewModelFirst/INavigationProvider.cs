
namespace ViewModelFirst
{
    public interface INavigationProvider
    {
        void GoForward(ViewModelBase viewModel);
        void GoBackward();
    }
}
