using System.Windows;

namespace SaleCakes.ViewModel;

public class MainWindowViewModel : BaseViewModel
{
    private ResizeMode _resizeModeMainWindow = ResizeMode.NoResize;
    private Visibility _visibilityAutorized = Visibility.Visible;
    private Visibility _visibilityConditer;
    private Visibility _visibilityEmployer;
    private Visibility _visibilityMenu = Visibility.Hidden;

    public MainWindowViewModel()
    {
        AuthorizedViewModel = ((Application.Current as App).ServiceProvider.GetService(typeof(AuthorizedViewModel)) as AuthorizedViewModel)!;
    }

    public AuthorizedViewModel AuthorizedViewModel { get; }

    public Visibility VisibilityAutorized
    {
        get => _visibilityAutorized;
        set
        {
            _visibilityAutorized = value;
            OnPropertyChanged(nameof(VisibilityAutorized));
        }
    }

    public Visibility VisibilityEmployer
    {
        get => _visibilityEmployer;
        set
        {
            _visibilityEmployer = value;
            OnPropertyChanged(nameof(VisibilityEmployer));
        }
    }

    public Visibility VisibilityConditer
    {
        get
        {
            var role = (Application.Current as App).RoleUser;

            if (role is "Кондитер")
            {
                _visibilityConditer = Visibility.Collapsed;
                _visibilityEmployer = Visibility.Collapsed;
                OnPropertyChanged(nameof(VisibilityEmployer));
            }
            else if (role is "Продавец")
            {
                _visibilityEmployer = Visibility.Collapsed;
                OnPropertyChanged(nameof(VisibilityEmployer));
            }

            return _visibilityConditer;
        }
    }

    public ResizeMode ResizeModeMainWindow
    {
        get => _resizeModeMainWindow;
        set
        {
            _resizeModeMainWindow = value;
            OnPropertyChanged(nameof(ResizeModeMainWindow));
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
        OnPropertyChanged(nameof(VisibilityEmployer));
        OnPropertyChanged(nameof(VisibilityConditer));
    }
}