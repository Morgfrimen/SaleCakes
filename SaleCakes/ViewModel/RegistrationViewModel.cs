using System;
using System.Collections.Generic;
using System.Windows;
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
    private readonly IAuthorizationUserRepositories _authorizationUserRepositories;
    private readonly AuthorizationUserModel _user = new AuthorizationUserModel(){AppUsers = new AppUsersModel()};
    private int _selectedRoleIndex;
    private readonly IEnumerable<string> _roleValue = new[] {"Директор", "Администратор", "Продавец" };

    public RegistrationViewModel(IAppUserRepositories appUserRepositories, IAuthorizationUserRepositories authorizationUserRepositories)
    {
        _appUserRepositories = appUserRepositories;
        _authorizationUserRepositories = authorizationUserRepositories;
        ContainerCommand = new RegistrationContainer(_user, _appUserRepositories,_authorizationUserRepositories);
    }

    public AuthorizationUserModel User
    {
        get => _user;
        set => OnPropertyChanged(nameof(User));
    }

    public IEnumerable<string> RoleValue => _roleValue;

    public int SelectedRoleIndex
    {
        get => _selectedRoleIndex;
        set { _selectedRoleIndex = value; OnPropertyChanged(nameof(SelectedRoleIndex)); }
    }

    public RegistrationContainer ContainerCommand { get; }

    public ICommand RegistrationCommand { get; } = new RelayCommand(async (obj) =>
    {
        var model = obj as RegistrationContainer;

        var roleDto = new RoleUserDto(model!.User.AppUsers.UserRole.Trim());
        var userDto = new AuthorizationUserDto(roleDto, model.User.UserLogin.Trim(), model.User.UserPassword.Trim(), DateTime.Now);

        var roleCreated = await model.AppUserRepositories.GetByRoleAsync(roleDto.UserRole.Trim());

        if (roleCreated.ResultOperation is null)
        {
            await model.AppUserRepositories.AddEntryAsync(roleDto);
        }

        var newUserId = await model.AuthorizationUserRepositories.AddEntryAsync(userDto);

        MessageBox.Show("Пользоваль зарегистрирован", "Информация", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
    });

    public class RegistrationContainer
    {
        public RegistrationContainer(AuthorizationUserModel user, IAppUserRepositories appUserRepositories, IAuthorizationUserRepositories authorizationUserRepositories)
        {
            User = user;
            AppUserRepositories = appUserRepositories;
            AuthorizationUserRepositories = authorizationUserRepositories;
        }

        public AuthorizationUserModel User { get; }
        public IAppUserRepositories AppUserRepositories { get; }
        public IAuthorizationUserRepositories AuthorizationUserRepositories { get; }
    }
}