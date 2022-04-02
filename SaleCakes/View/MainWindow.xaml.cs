using SaleCakes.View.Pages;
using System.Windows;

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