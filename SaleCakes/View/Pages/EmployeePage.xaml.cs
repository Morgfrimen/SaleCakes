using System;
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

    private void ButtonEdit_Click(object sender, RoutedEventArgs e)
    {
    }

    private void ListViewItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        EmployeeEditDeleteWindow employeeEditDeleteWindow = new EmployeeEditDeleteWindow();
        employeeEditDeleteWindow.Show();
        //var id = ListViewItem.FocusedItem.SubItems[5].Text;
    }
}