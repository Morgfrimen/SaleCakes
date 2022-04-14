using System.Windows;
using SaleCakes.ViewModel;

namespace SaleCakes.View;

/// <summary>
///     Логика взаимодействия для RegistrationWindow.xaml
/// </summary>
public partial class RegistrationWindow : Window
{
    public RegistrationWindow(RegistrationViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }

    private void Close_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.MainWindow.WindowState = WindowState.Normal;
        Close();
    }
}