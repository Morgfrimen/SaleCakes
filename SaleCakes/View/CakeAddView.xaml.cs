using System.Windows;

namespace SaleCakes.View;

/// <summary>
///     Логика взаимодействия для CakeAddView.xaml
/// </summary>
public partial class CakeAddView : Window
{
    public CakeAddView()
    {
        InitializeComponent();
    }

    private void Exit(object sender, RoutedEventArgs e)
    {
        Close();
    }
}