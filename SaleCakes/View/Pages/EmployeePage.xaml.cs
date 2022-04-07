using System.Windows;
using System.Windows.Controls;
using SaleCakes.ViewModel;

namespace SaleCakes.View.Pages;

/// <summary>
///     Логика взаимодействия для EmployeePage.xaml
/// </summary>
public partial class EmployeePage : Page
{
    private readonly EmployeeViewModel _employeeViewModel;

    public EmployeePage(EmployeeViewModel employeeViewModel)
    {
        _employeeViewModel = employeeViewModel;
        InitializeComponent();
        DataContext = _employeeViewModel;
    }

    private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void ButtonEdit_Click(object sender, RoutedEventArgs e)
    {
    }
}