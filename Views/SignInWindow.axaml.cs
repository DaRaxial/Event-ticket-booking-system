using Avalonia.Controls;
using EventSeatManager.ViewModels;

namespace EventSeatManager.Views
{
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}