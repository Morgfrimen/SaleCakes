using System;
using System.Windows.Input;
using Data.Dto;
using Data.Repositories;
using Data.Repositories.Abstract;
using SaleCakes.Command;
using SaleCakes.Model;

namespace SaleCakes.ViewModel;

public class RegistrationViewModel : BaseViewModel
{
    private readonly IAppUserRepositories _appUserRepositories;
    private readonly AuthorizationUserModel _user = new AuthorizationUserModel(){AppUsers = new AppUsersModel()};

    public RegistrationViewModel(IAppUserRepositories appUserRepositories)
    {
        _appUserRepositories = appUserRepositories;
        ContainerCommand = new RegistrationContainer(_user, _appUserRepositories);
    }

    public AuthorizationUserModel User
    {
        get => _user;
        set => OnPropertyChanged(nameof(User));
    }

    public RegistrationContainer ContainerCommand { get; }

    public ICommand RegistrationCommand { get; } = new RelayCommand(async (obj) =>
    {
        var model = obj as RegistrationContainer;

        var roleDto = new RoleUserDto(model!.User.AppUsers.UserRole);
        var userDto = new AuthorizationUserDto(roleDto, model.User.UserLogin, model.User.UserPassword, DateTime.Now);

        await model.Repos.AddEntryAsync(roleDto); //TODO: UserRepos
    });

    public class RegistrationContainer
    {
        public RegistrationContainer(AuthorizationUserModel user, IAppUserRepositories repos)
        {
            User = user;
            Repos = repos;
        }

        public AuthorizationUserModel User { get; }
        public IAppUserRepositories Repos { get; }
    }
}