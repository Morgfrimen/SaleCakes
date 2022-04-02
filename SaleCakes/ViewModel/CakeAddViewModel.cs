using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Data.Legacy.Dto;
using Data.Legacy.Resositoryes;
using SaleCakes.Command;
using SaleCakes.Model;

namespace SaleCakes.ViewModel;

public class CakeAddViewModel : BaseViewModel
{
    private TierContainer _tier = new TierContainer();

    public class StuffingContainer
    {
        public Guid StuffigAddGuidLast { get; set; }
    }



    public class TierContainer
    {
        public Guid Stuffig{ get; set; }
        public Guid Decor { get; set; }
        public Guid Shortcake { get; set; }

        public CakeViewModel ParentCakeViewModel { get; set; }

        public List<Guid> TierdId = new List<Guid>();

        public uint Count { get; set; }
    }

    public StuffingContainer Stuffing { get; set; } = new StuffingContainer();

    public CakeAddViewModel(CakeViewModel parentCakeViewModel)
    {
        _tier.ParentCakeViewModel = parentCakeViewModel;
    }

   

    public ICommand AddStuffing { get; } = new RelayCommand(async (obj) =>
    {
        var reposStuffing = new StuffingRepos(App.ConnectionString);
        var model = new StuffingDto("Теcn", 800);
        await reposStuffing.AddAsync(model);
        var allStuffing = await reposStuffing.GetAllAsync();
        var selectStuffing = allStuffing.FirstOrDefault(item => item.Name == "Теcn");
        var stuffing = obj as TierContainer;
        stuffing.Stuffig = selectStuffing.Id;

    });


    //Stuffing,Decor,ShortcakeEntry
    public TierContainer Tier
    {
        get => _tier;
    }

    public ICommand AddDecor { get; } = new RelayCommand(async (obj) =>
    {
        var reposStuffing = new DecorRepos(App.ConnectionString);
        var model = new DecorDto("Теcn", 1000);
        await reposStuffing.AddAsync(model);
        var allStuffing = await reposStuffing.GetAllAsync();
        var decorDto = allStuffing.FirstOrDefault(item => item.Name == "Теcn");
        var stuffing = obj as TierContainer;
        stuffing.Decor = decorDto.Id;

    });
    public ICommand AddShortcake { get; } = new RelayCommand(async (obj) =>
    {
        var reposStuffing = new ShortcakeRepos(App.ConnectionString);
        var model = new ShortcakeDto("2312312asdfasd", 800);
        await reposStuffing.AddAsync(model);
        var allStuffing = await reposStuffing.GetAllAsync();
        var selectStuffing = allStuffing.FirstOrDefault(item => item.Name == "2312312asdfasd");
        var stuffing = obj as TierContainer;
        stuffing.Shortcake = selectStuffing.Id;

    });

    public ICommand AddCake { get; } = new RelayCommand(async (obj) =>
    {
        var tierContainer = (TierContainer)obj;
        var cakeRepos = new CakeRepos(App.ConnectionString);
        var cakeDto = new CakeDto(500, tierContainer.TierdId.LastOrDefault());
        await cakeRepos.AddAsync(cakeDto);
        var collection = await cakeRepos.GetAllAsync();
        var model = collection.LastOrDefault();

        tierContainer.ParentCakeViewModel.ModelCakes.Add(new ModelCake(model.Id,model.Weight,model.TiersId)
            {Number = (uint)(tierContainer.ParentCakeViewModel.ModelCakes.Count + 1)});
        tierContainer.ParentCakeViewModel.UpdateAllProperty();

    });

    public ICommand AddTier { get; } = new RelayCommand(async (obj) =>
    {
        var tierContainer = (TierContainer)obj;
        var tierRepos = new TiersRepos(App.ConnectionString);
        var tiersDto = new TiersDto(tierContainer.Stuffig, tierContainer.Decor, tierContainer.Shortcake);
        await tierRepos.AddAsync(tiersDto);
        var collection = await tierRepos.GetAllAsync();
        var tierDto = collection.FirstOrDefault(item => item.DecorId == tierContainer.Decor); 
        tierContainer.TierdId.Add(tierDto.Id);
        tierContainer.Count++;
    });

    public override void UpdateAllProperty()
    {
        throw new NotImplementedException();
    }
}