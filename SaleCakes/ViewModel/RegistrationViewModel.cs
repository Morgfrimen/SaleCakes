using System;
using System.Collections.Generic;
using System.Linq;
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
    public IAppUserRepositories AppUserRepositories { get; }
    public IAuthorizationUserRepositories UserRepositories { get; }
    private readonly AuthorizationUserModel _user = new AuthorizationUserModel(){AppUsers = new AppUsersModel()};
    private int _selectedRoleIndex;
    private readonly IEnumerable<string> _roleValue = new[] {"Кондитер", "Администратор", "Продавец" };

    public RegistrationViewModel(IAppUserRepositories appUserRepositories, IAuthorizationUserRepositories authorizationUserRepositories)
    {
        AppUserRepositories = appUserRepositories;
        UserRepositories = authorizationUserRepositories;
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
    
    public ICommand RegistrationCommand { get; } = new RelayCommand(async (obj) =>
    {
        var model = obj as RegistrationViewModel;

        var listRole = model.RoleValue.ToList();

        var roleDto = new RoleUserDto(listRole[model.SelectedRoleIndex].Trim());
        var userDto = new AuthorizationUserDto(roleDto, model.User.UserLogin.Trim(), model.User.UserPassword.Trim(), DateTime.Now);

        var roleCreated = await model.AppUserRepositories.GetByRoleAsync(roleDto.UserRole.Trim());

        if (roleCreated.ResultOperation is null)
        {
            await model.AppUserRepositories.AddEntryAsync(roleDto);
        }

        var newUserId = await model.UserRepositories.AddEntryAsync(userDto);

        MessageBox.Show("Пользоваль зарегистрирован", "Информация", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
    });

   
}