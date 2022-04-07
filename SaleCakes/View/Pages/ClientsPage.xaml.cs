using System.Windows;
using System.Windows.Controls;
using SaleCakes.ViewModel;

namespace SaleCakes.View.Pages;

/// <summary>
///     Логика взаимодействия для ClientsPage.xaml
/// </summary>
public partial class ClientsPage : Page
{
    private ClientsViewModel? _clientsViewModel = new();
    public ClientsPage(ClientsViewModel clientsViewModel)
    {
        InitializeComponent();
        _clientsViewModel = clientsViewModel;
        DataContext = _clientsViewModel;
    }


    private void ButtonEdit_Click(object sender, RoutedEventArgs e)
    {
    }
}