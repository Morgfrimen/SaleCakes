using SaleCakes.Command;
using SaleCakes.Extension;
using SaleCakes.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Data.Legacy.Resositoryes;

namespace SaleCakes.ViewModel;

public class CakeViewModel : BaseViewModel
{
    private ObservableCollection<ModelCake> _modelCakes = new ObservableCollection<ModelCake>();
    private ObservableCollection<ModelStuffing> _stuffings;

    public ObservableCollection<ModelCake> ModelCakes
    {
        get => _modelCakes;
        set
        {
            _modelCakes = value;
            OnPropertyChanged(nameof(ModelCakes));
        }
    }

    public ObservableCollection<ModelStuffing> Stuffings
    {
        get {return _stuffings;
        }
        set { _stuffings = value; OnPropertyChanged(nameof(Stuffings)); }
    }

    internal ICommand LoadModes { get; } = new RelayCommand( async (cakes) =>
    {
        var cakeRepos = new CakeRepos(App.ConnectionString);
        var cakeDtos = await cakeRepos.GetAllAsync();

        if(cakeDtos is null)
            return;

        var cak = cakes as ObservableCollection<ModelCake>;

        cak.Clear();
        var listCakeModel = new List<ModelCake>();
        var count = default(uint);
        foreach (var cakeDto in cakeDtos)
        {
            count++;
            var modes = new ModelCake(cakeDto.Id, cakeDto.Weight, cakeDto.TiersId){Number = count};
            listCakeModel.Add(modes);
        }

        cak = cak.AddRange(listCakeModel);
    });

    public override void UpdateAllProperty()
    {
        OnPropertyChanged(nameof(Stuffings));
        OnPropertyChanged(nameof(ModelCakes));
    }
}