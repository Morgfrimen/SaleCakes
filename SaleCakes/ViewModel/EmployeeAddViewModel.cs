using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Data.Legacy.Dto;
using Data.Legacy.Resositoryes;
using SaleCakes.Command;

namespace SaleCakes.ViewModel
{
    public class EmployeeAddViewModel : BaseViewModel
    {


        public ICommand AddEmployee { get; } = new RelayCommand(async (obj) =>
        {
            var roleTitle = obj as string;
            var repostRole = new RoleUserRepos(App.ConnectionString);
            var roles = await repostRole.GetAllAsync();
            var selectedRole = roles.FirstOrDefault(item=> item.UserRole == roleTitle);

            if (selectedRole is null)
            {
                var newRole = await repostRole.AddAsync(new RoleUserDto(roleTitle));
                roles = await repostRole.GetAllAsync();
                selectedRole = roles.FirstOrDefault(item => item.UserRole == roleTitle);
            }

            var reposStuffing = new EmployeeRepos(App.ConnectionString);
            var model = new EmployeeDto(selectedRole.Id,"tName", "tSurname", "tPatr", "88005553535", "tEmail");
            await reposStuffing.AddAsync(model);
            var allStuffing = await reposStuffing.GetAllAsync();
            var selectStuffing = allStuffing.FirstOrDefault(item => item.AutorizedUserId == selectedRole.Id); 
            var stuffing = obj as CakeAddViewModel.TierContainer;
            stuffing.Stuffig = selectStuffing.Id;

        });

        


        public override void UpdateAllProperty()
        {
            throw new NotImplementedException();
        }
    }
}
