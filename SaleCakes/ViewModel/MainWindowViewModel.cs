using System;
using System.Windows;

namespace SaleCakes.ViewModel;

public class MainWindowViewModel : BaseViewModel
{
    private Visibility _visibilityAutorized = Visibility.Visible;
    private Visibility _visibilityMenu = Visibility.Hidden;
    private ResizeMode _resizeModeMainWindow;

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