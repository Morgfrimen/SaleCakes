using System.Windows;
using SaleCakes.View.Components;

namespace SaleCakes.View;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainMenuComponent _mainMenuComponent;

    public MainWindow(MainMenuComponent mainMenuComponent)
    {
        _mainMenuComponent = mainMenuComponent;
        InitializeComponent();
        _ = FrameMenuPage.Navigate(_mainMenuComponent);
    }
}