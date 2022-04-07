using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SaleCakes.Command;
using SaleCakes.Model;

namespace SaleCakes.ViewModel
{
    public class ClientsViewModel : BaseViewModel
    {
        private ObservableCollection<ClientModel> _clientViewModels = new()
        {
            new ClientModel(Guid.NewGuid(), "Name1", "Surname1", "Patr1",
                "79999999999", "mail1", Guid.NewGuid()),
            new ClientModel(Guid.NewGuid(), "Name2", "Surname2", "Patr2",
                "79999999992", "mail2", Guid.NewGuid())
        };

        public ObservableCollection<ClientModel> ModelClients
        {
            get => _clientViewModels;
            set
            {
                _clientViewModels = value;
                OnPropertyChanged(nameof(ModelClients));
            }
        }

        internal ICommand LoadModes { get; } = new RelayCommand(async clients =>
        {
            //var cakeRepos = new CakeRepos(App.ConnectionString);
            //var cakeDtos = await cakeRepos.GetAllAsync();

            //if (cakeDtos is null)
            //{
            //    return;
            //}

            //var cak = cakes as ObservableCollection<CakeModel>;

            //cak.Clear();
            //var listCakeModel = new List<CakeModel>();
            //var count = default(uint);

            //foreach (var cakeDto in cakeDtos)
            //{
            //    count++;
            //    var modes = new CakeModel(cakeDto.Id, cakeDto.Weight, cakeDto.TiersId) { Number = count };
            //    listCakeModel.Add(modes);
            //}

            //cak = cak.AddRange(listCakeModel);
        });
    }
}
