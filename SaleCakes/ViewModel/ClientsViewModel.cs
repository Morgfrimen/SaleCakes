using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SaleCakes.Command;
using SaleCakes.Model;

namespace SaleCakes.ViewModel;

public class ClientsViewModel : BaseViewModel
{
    private ObservableCollection<ClientModel> _client = new()
    {
        new ClientModel(Guid.NewGuid(),
            "Name1",
            "Surname1",
            "Patr1",
            "79999999999",
            "mail1Client@mail.com",
            Guid.NewGuid()),
        new ClientModel(Guid.NewGuid(),
            "Name2",
            "Surname2",
            "Patr2",
            "79999999992",
            "mail2Client@mail.com",
            Guid.NewGuid()),
        new ClientModel(Guid.NewGuid(),
            "Name3",
            "Surname3",
            "Patr3",
            "79999999993",
            "mail3Client@mail.com",
            Guid.NewGuid()),
        new ClientModel(Guid.NewGuid(),
            "Name4",
            "Surname4",
            "Patr4",
            "79999999994",
            "mail4Client@mail.com",
            Guid.NewGuid())
    };

    private ClientModel _clientModelNew;
    private Container _containers;

    public ClientsViewModel()
    {
        _clientModelNew = new ClientModel();
        Containers = new Container { ClientModel = _clientModelNew, Collection = _client, ViewModel = this };
    }

    public ICommand AddClient { get; } = new RelayCommand(async obj =>
    {
        var container = obj as Container;

        container.Collection.Add(container.ClientModel);
        container.ViewModel.ClientModelNew = new ClientModel();
        container.ViewModel.UpdateAllProperty();

        container.ViewModel.Containers = new Container
        {
            Collection = container.ViewModel.Client,
            ClientModel = container.ViewModel.ClientModelNew,
            ViewModel = container.ViewModel
        };
    });

    public ClientModel ClientModelNew
    {
        get
        {
            _clientModelNew ??= new ClientModel();
            return _clientModelNew;
        }
        set
        {
            _clientModelNew = value;
            OnPropertyChanged(nameof(ClientModelNew));
        }
    }

    public ObservableCollection<ClientModel> Client
    {
        get => _client;
        set
        {
            _client = value;
            OnPropertyChanged(nameof(Client));
        }
    }

    public Container Containers
    {
        get => _containers;
        set
        {
            _containers = value;
            OnPropertyChanged(nameof(Containers));
        }
    }

    public override void UpdateAllProperty()
    {
        OnPropertyChanged(nameof(Client));
        OnPropertyChanged(nameof(Containers));
        OnPropertyChanged(nameof(ClientModelNew));
    }

    public class Container
    {
        public ClientModel ClientModel { get; set; }
        public ObservableCollection<ClientModel> Collection { get; set; }
        public ClientsViewModel ViewModel { get; set; }
    }
}