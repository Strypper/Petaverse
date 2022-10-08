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
        public ICommand LoveCommand { get; set; }

        private readonly IPetShortService _petShortService;
        public ICollection<PetShort> PetShorts { get; set; } = new ObservableCollection<PetShort>();
        public PetShortsPageViewModel()
        {
            _petShortService = Ioc.Default.GetRequiredService<IPetShortService>();
            LoveCommand = new AsyncRelayCommand(LovePost);
            InitFirstVideo();
        }

        private async Task LovePost()
        {
            CurrentPetShort.IsLoved = !CurrentPetShort.IsLoved;
        }

        private async Task InitFirstVideo()
        {
            var petShortsList = await _petShortService.GetAllPetShortsAsync();
            petShortsList.ForEach(petShort =>
            {
                PetShorts.Add(petShort);
             });
            if(PetShorts.Count > 0)
            {
                var firstPetShort = PetShorts.FirstOrDefault();
                firstPetShort.MediaUrl = firstPetShort.Media.MediaUrl;
            }
        }
    }
}
