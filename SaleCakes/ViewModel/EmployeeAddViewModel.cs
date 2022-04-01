using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Data.Dto;
using Data.Resositoryes;
using SaleCakes.Command;

namespace SaleCakes.ViewModel
{
    public class EmployeeAddViewModel : BaseViewModel
    {


        public ICommand AddEmployee { get; } = new RelayCommand(async (obj) =>
        {
            var reposStuffing = new EmployeeRepos(App.ConnectionString);
            var model = new EmployeeDto("tName", "tSurname","tPatr","88005553535","tEmail");
            await reposStuffing.AddAsync(model);
            var allStuffing = await reposStuffing.GetAllAsync();
            var selectStuffing = allStuffing.FirstOrDefault(item => item.Name == "Теcn");
            var stuffing = obj as CakeAddViewModel.TierContainer;
            stuffing.Stuffig = selectStuffing.Id;

        });


        public override void UpdateAllProperty()
        {
            throw new NotImplementedException();
        }
    }
}
