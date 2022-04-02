using System;
using System.Windows;

namespace SaleCakes.ViewModel;

public class MainWindowViewModel : BaseViewModel
{
    private Visibility _visibilityAutorized = Visibility.Visible;
    private Visibility _visibilityMenu = Visibility.Hidden;

    public Visibility VisibilityAutorized
    {
        get => _visibilityAutorized;
        set
        {
            _visibilityAutorized = value;
            OnPropertyChanged(nameof(VisibilityAutorized));
        }
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