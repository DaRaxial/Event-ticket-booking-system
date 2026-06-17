using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using EventSeatManager.ViewModels;
using System.Linq;

namespace EventSeatManager;

public partial class SeatButton : UserControl
{
    public SeatButton()
    {
        InitializeComponent();
    }

    private void AddBookSeat(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var button = sender as Button;
        if (button == null) return;

        // Извлекаем ID места из Content кнопки
        if (!int.TryParse(button.Content?.ToString(), out int seatId))
            return;

        // Находим родительскую ViewModel
        var parentVm = FindParentViewModel();
        if (parentVm == null) return;

        // Ищем объект Seats в коллекции Seats (всех местах) по ID
        var seat = parentVm.Seats?.FirstOrDefault(s => s.Id == seatId);
        if (seat == null) return;

        // Вызываем команду добавления места в BookedSeats
        parentVm.AddSeatPlaceCommand.Execute(seat);

        // Визуальная обратная связь: меняем цвет кнопки на жёлтый
        button.Background = new Avalonia.Media.SolidColorBrush(Avalonia.Media.Color.FromRgb(0, 84, 1));
    }
    private BookingPageViewModel? FindParentViewModel()
    {
        var parent = this.FindAncestorOfType<ItemsControl>();
        return parent?.DataContext as BookingPageViewModel;
    }
}