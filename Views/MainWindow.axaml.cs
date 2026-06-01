using Avalonia.Controls;
using EventSeatManager.ViewModels;

namespace EventSeatManager.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(typeof(LoginPage));
        }
    }
}