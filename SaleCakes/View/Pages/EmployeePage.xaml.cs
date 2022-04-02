using System.Windows;
using System.Windows.Controls;

namespace SaleCakes.View.Pages;

/// <summary>
///     Логика взаимодействия для EmployeePage.xaml
/// </summary>
public partial class EmployeePage : Page
{
    public EmployeePage()
    {
        InitializeComponent();
    }

    private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void ButtonEdit_Click(object sender, RoutedEventArgs e)
    {
    }
}