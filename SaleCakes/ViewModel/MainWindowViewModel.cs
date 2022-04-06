using System;
using System.Windows;

namespace SaleCakes.ViewModel;

public class MainWindowViewModel : BaseViewModel
{
    public AuthorizedViewModel AuthorizedViewModel { get; }
    private Visibility _visibilityAutorized = Visibility.Visible;
    private Visibility _visibilityMenu = Visibility.Hidden;
    private ResizeMode _resizeModeMainWindow = ResizeMode.NoResize;

    public MainWindowViewModel()
    {
        AuthorizedViewModel = ((App.Current as App).ServiceProvider.GetService(typeof(AuthorizedViewModel)) as AuthorizedViewModel)!;
    }

    public Visibility VisibilityAutorized
    {
        get => _visibilityAutorized;
        set
        {
            _visibilityAutorized = value;
            OnPropertyChanged(nameof(VisibilityAutorized));
        }
    }

    public ResizeMode ResizeModeMainWindow
    {
        get => _resizeModeMainWindow;
        set { _resizeModeMainWindow = value;
            OnPropertyChanged(nameof(ResizeModeMainWindow)); }
    }

    public Visibility VisibilityMenu
    {
        get => _visibilityMenu;
        set
        {
            _visibilityMenu = value;
            OnPropertyChanged(nameof(VisibilityMenu));
        }
    }

    public override void UpdateAllProperty()
    {
        throw new NotImplementedException();
    }
}