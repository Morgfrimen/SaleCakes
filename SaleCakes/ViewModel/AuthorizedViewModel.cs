using System.Windows;
using System.Windows.Input;
using Data.Repositories.Abstract;
using SaleCakes.Command;

namespace SaleCakes.ViewModel;

public class AuthorizedViewModel : BaseViewModel
{
    private readonly IAuthorizationUserRepositories _authorizationUserRepositories;
    private string _login;
    private string _password;
    private Container _containers ;

    public AuthorizedViewModel(IAuthorizationUserRepositories authorizationUserRepositories)
    {
        _authorizationUserRepositories = authorizationUserRepositories;
        _containers = new Container(_login, _password, _authorizationUserRepositories);
    }

    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            _containers.Login = value;
            OnPropertyChanged(nameof(Login));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            _containers.Password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public ICommand LogInCommand { get; } = new RelayCommand(async (obj) =>
    {
        var container = obj as Container;

        var resultDto = await container!.AuthorizationUserRepositories.GetAuthorizationUserDtoByLoginAsync(container?.Login?.Trim() ?? string.Empty);

        if(resultDto.ResultOperation is null || resultDto.ResultOperation.UserPassword != container.Password)
        {
            MessageBox.Show("Неверный пароль");
            return;
        }

        var mainVM = (App.Current as App).ServiceProvider.GetService(typeof(MainWindowViewModel)) as MainWindowViewModel;

        mainVM.VisibilityAutorized = Visibility.Collapsed;
        mainVM.VisibilityMenu = Visibility.Visible;
        mainVM.ResizeModeMainWindow = ResizeMode.CanResizeWithGrip;


    });

    public Container Containers
    {
        get => _containers;
        set
        {
            _containers = value;
            OnPropertyChanged(nameof(Containers));
        }
    }

    public class Container
    {
        public Container(string login, string password, IAuthorizationUserRepositories authorizationUserRepositories)
        {
            Login = login;
            Password = password;
            AuthorizationUserRepositories = authorizationUserRepositories;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public IAuthorizationUserRepositories AuthorizationUserRepositories { get; }
    }
}