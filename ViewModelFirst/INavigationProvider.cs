
namespace ViewModelFirst
{
    public interface INavigationProvider
    {
        //void GoForward(ViewModelBase viewModel);
        void Navigate(string actionName, params object[] actionParameters);
        void GoBackward();
    }
}
