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
            var navigationProvider = ObjBuilder.GetNavigationProvider();

            navigationProvider.Navigate("initialScreen");

            DataContext = navigationProvider;
        }
    }
}
