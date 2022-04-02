using System.Windows;
using SaleCakes.View.Pages;

namespace SaleCakes.View;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainMenuPage _mainMenuPage;

    public MainWindow(MainMenuPage mainMenuPage)
    {
        _mainMenuPage = mainMenuPage;
        InitializeComponent();
        _ = FrameMenuPage.Navigate(_mainMenuPage);
    }
}