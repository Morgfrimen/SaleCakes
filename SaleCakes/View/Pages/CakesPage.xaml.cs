using SaleCakes.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace SaleCakes.View.Pages;

/// <summary>
///     Логика взаимодействия для CakesPage.xaml
/// </summary>
public partial class CakesPage : Page
{
    private readonly CakeAddView _cakeAddView;
    private CakeViewModel? _cakeViewModel = new();

    public CakesPage(CakeAddView cakeAddView)
    {
        _cakeAddView = cakeAddView;
        InitializeComponent();
        StartPage();
    }

    private void StartPage()
    {
        _cakeViewModel = DataContext as CakeViewModel;
        _cakeViewModel!.LoadModes.Execute(_cakeViewModel.ModelCakes);
    }

    private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void ButtonEdit_Click(object sender, RoutedEventArgs e)
    {
    }

    private void Button_OpenAddCake_OnClick(object sender, RoutedEventArgs e)
    {
        CakeAddView? cakeAddView = new() { DataContext = new CakeAddViewModel(_cakeViewModel) };
        cakeAddView.Show();
    }
}