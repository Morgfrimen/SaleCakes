using SaleCakes.Command;
using SaleCakes.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SaleCakes.ViewModel;

public class CakeViewModel : BaseViewModel
{
    private ObservableCollection<CakeModel> _modelCakes = new();
    private ObservableCollection<StuffingModel> _stuffings = null!;

    public ObservableCollection<CakeModel> ModelCakes
    {
        get => _modelCakes;
        set
        {
            _modelCakes = value;
            OnPropertyChanged(nameof(ModelCakes));
        }
    }

    public ObservableCollection<StuffingModel> Stuffings
    {
        get => _stuffings;
        set
        {
            _stuffings = value;
            OnPropertyChanged(nameof(Stuffings));
        }
    }

    internal ICommand LoadModes { get; } = new RelayCommand(async cakes =>
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

    public override void UpdateAllProperty()
    {
        OnPropertyChanged(nameof(Stuffings));
        OnPropertyChanged(nameof(ModelCakes));
    }
}