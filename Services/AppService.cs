using FluentAvalonia.UI.Controls;

namespace EventSeatManager.Services
{
    public static class AppService
    {
        public static Frame? MainFrame { get; private set; }

        public static void Initialize(Frame mainFrame)
        {
            MainFrame = mainFrame;
        }
    }
}
