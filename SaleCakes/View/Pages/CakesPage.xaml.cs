using System.Windows;
using System.Windows.Controls;
using SaleCakes.ViewModel;

namespace SaleCakes.View.Pages;

/// <summary>
///     Логика взаимодействия для CakesPage.xaml
/// </summary>
public partial class CakesPage : Page
{
    private CakeViewModel? _cakeViewModel = new();
    private CakeAddView? _cakeAddView;

    public CakesPage()
    {
        InitializeComponent();
        _cakeViewModel = DataContext as CakeViewModel;
        _cakeViewModel!.LoadModes.Execute(_cakeViewModel.ModelCakes);
    }

    private void Button_OpenAddCake_OnClick(object sender, RoutedEventArgs e)
    {
        _cakeAddView ??= new() { DataContext = new CakeAddViewModel(_cakeViewModel) };
        if(!_cakeAddView.IsActive)
            _cakeAddView.Show();
    }
    
    private void ListViewItem_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.Focus();
        _cakeAddView ??= new() { DataContext = new CakeAddViewModel(_cakeViewModel) };
        if (!_cakeAddView.IsActive)
            _cakeAddView.Show();
    }

}