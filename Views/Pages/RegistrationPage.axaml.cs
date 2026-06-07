using Avalonia.Controls;
using EventSeatManager.ViewModels;

namespace EventSeatManager;

public partial class RegistationPage : UserControl
{
    public RegistationPage()
    {
        InitializeComponent();
        DataContext = new RegistrationPageViewModel();
    }
}