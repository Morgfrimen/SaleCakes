using System.Windows;

namespace SaleCakes.View;

/// <summary>
///     Логика взаимодействия для EmployeeAddView.xaml
/// </summary>
public partial class EmployeeAddView : Window
{
    public EmployeeAddView()
    {
        InitializeComponent();
    }

    private void Exit(object sender, RoutedEventArgs e)
    {
        Close();
    }
}