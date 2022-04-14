using System;
using System.Collections.Generic;
using System.Windows.Input;
using SaleCakes.Command;

namespace SaleCakes.ViewModel;

public class CakeAddViewModel : BaseViewModel
{
    public CakeAddViewModel(CakeViewModel? parentCakeViewModel)
    {
        Tier.ParentCakeViewModel = parentCakeViewModel;
    }

    public StuffingContainer Stuffing { get; set; } = new();

    public ICommand AddStuffing { get; } = new RelayCommand(async obj =>
    {
        //var reposStuffing = new StuffingRepos(App.ConnectionString);
        //var model = new StuffingDto("Теcn", 800);
        //await reposStuffing.AddAsync(model);
        //var allStuffing = await reposStuffing.GetAllAsync();
        //var selectStuffing = allStuffing.FirstOrDefault(item => item.Name == "Теcn");
        //var stuffing = obj as TierContainer;
        //stuffing.Stuffig = selectStuffing.Id;
    });

    //Stuffing,DecorPage,ShortcakeEntry
    public TierContainer Tier { get; } = new();

    public ICommand AddDecor { get; } = new RelayCommand(async obj =>
    {
        //var reposStuffing = new DecorRepos(App.ConnectionString);
        //var model = new DecorDto("Теcn", 1000);
        //await reposStuffing.AddAsync(model);
        //var allStuffing = await reposStuffing.GetAllAsync();
        //var decorDto = allStuffing.FirstOrDefault(item => item.Name == "Теcn");
        //var stuffing = obj as TierContainer;
        //stuffing.Decor = decorDto.Id;
    });

    public ICommand AddShortcake { get; } = new RelayCommand(async obj =>
    {
        //var reposStuffing = new ShortcakeRepos(App.ConnectionString);
        //var model = new ShortcakeDto("2312312asdfasd", 800);
        //await reposStuffing.AddAsync(model);
        //var allStuffing = await reposStuffing.GetAllAsync();
        //var selectStuffing = allStuffing.FirstOrDefault(item => item.Name == "2312312asdfasd");
        //var stuffing = obj as TierContainer;
        //stuffing.Shortcake = selectStuffing.Id;
    });

    public ICommand AddCake { get; } = new RelayCommand(async obj =>
    {
        //var tierContainer = (TierContainer)obj;
        //var cakeRepos = new CakeRepos(App.ConnectionString);
        //var cakeDto = new CakeDto(500, tierContainer.TierdId.LastOrDefault());
        //await cakeRepos.AddAsync(cakeDto);
        //var collection = await cakeRepos.GetAllAsync();
        //var model = collection.LastOrDefault();

        //tierContainer.ParentCakeViewModel.ModelCakes.Add(new CakeModel(model.Id, model.Weight, model.TiersId)
        //    { Number = (uint)(tierContainer.ParentCakeViewModel.ModelCakes.Count + 1) });
        //tierContainer.ParentCakeViewModel.UpdateAllProperty();
    });

    public ICommand AddTier { get; } = new RelayCommand(async obj =>
    {
        //var tierContainer = (TierContainer)obj;
        //var tierRepos = new TiersRepos(App.ConnectionString);
        //var tiersDto = new TiersDto(tierContainer.Stuffig, tierContainer.Decor, tierContainer.Shortcake);
        //await tierRepos.AddAsync(tiersDto);
        //var collection = await tierRepos.GetAllAsync();
        //var tierDto = collection.FirstOrDefault(item => item.DecorModel == tierContainer.Decor);
        //tierContainer.TierdId.Add(tierDto.Id);
        //tierContainer.Count++;
    });

    public override void UpdateAllProperty()
    {
        throw new NotImplementedException();
    }

    public class StuffingContainer
    {
        public Guid StuffigAddGuidLast { get; set; }
    }

    public class TierContainer
    {
        public List<Guid> TierdId = new();
        public Guid Stuffig { get; set; }
        public Guid Decor { get; set; }
        public Guid Shortcake { get; set; }

        public CakeViewModel? ParentCakeViewModel { get; set; }

        public uint Count { get; set; }
    }
}