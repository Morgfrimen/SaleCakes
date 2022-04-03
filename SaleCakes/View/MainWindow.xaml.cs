using System.Windows;
using System.Windows.Navigation;
using SaleCakes.View.Components;
using SaleCakes.View.Pages;

namespace SaleCakes.View;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly CakesPage _cakesPage;

    public MainWindow(CakesPage cakesPage)
    {
        _cakesPage = cakesPage;
        InitializeComponent();
        
    }

    private void NavigateToCakesPageOnClick(object sender, RoutedEventArgs e)
    {
        while (FrameMenuPage.NavigationService.CanGoBack) 
            FrameMenuPage.NavigationService.GoBack();
        _ = FrameMenuPage.Navigate(_cakesPage);

    }
}