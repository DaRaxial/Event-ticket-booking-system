using FluentAvalonia.UI.Controls;

namespace EventSeatManager.Services.Navigation
{
    // Класс-инструмент для навигации между страницами
    public static class AppNavigationService
    {
        public static Frame? MainFrame { get; private set; }

        public static void Initialize(Frame mainFrame)
        {
            MainFrame = mainFrame;
        }
    }
}
