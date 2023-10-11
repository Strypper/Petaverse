using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WinRTXamlToolkit.Tools;

namespace Petaverse.ViewModels
{
    public partial class PetShortsPageViewModel : ViewModelBase
    {
        [ObservableProperty]
        private PetShort currentPetShort;

        [ObservableProperty]
        public ObservableCollection<PetShort> petShorts;
        public ICommand LoveCommand { get; set; }

        private readonly IPetShortService _petShortService;

        public PetShortsPageViewModel()
        {
            _petShortService = Ioc.Default.GetRequiredService<IPetShortService>();
            LoveCommand = new AsyncRelayCommand(LovePost);
        }

        private async Task LovePost()
        {
            CurrentPetShort.IsLoved = !CurrentPetShort.IsLoved;
        }

        public async Task InitFirstVideo()
        {
            //var petShorts = await _petShortService.GetAllPetShortsAsync();
            //petShorts.ToList().ForEach(petShort => PetShorts.Add(petShort));
            PetShorts = await _petShortService.GetAllPetShortsAsync();
            if(PetShorts?.Count > 0)
            {
                var firstPetShort = PetShorts.FirstOrDefault();
                firstPetShort.MediaUrl = firstPetShort.Media != null ? firstPetShort.Media.MediaUrl : "";
            }
        }
    }
}
