using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using PetaVerse.Models.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Petaverse.ViewModels
{
    public partial class PetShortsPageViewModel : ViewModelBase
    {
        [ObservableProperty]
        private PetShort currentPetShort;
        public ObservableCollection<PetShort> PetShorts { get; set; } = new ObservableCollection<PetShort>();
        public ICommand LoveCommand { get; set; }
        public PetShortsPageViewModel()
        {
            LoveCommand = new AsyncRelayCommand(LovePost);
            PetShorts = DemoPetShortData.GetPetShortsList();
            InitFirstVideo(PetShorts);
        }

        private async Task LovePost()
        {
            CurrentPetShort.IsLoved = !CurrentPetShort.IsLoved;
        }

        private void InitFirstVideo(ObservableCollection<PetShort> petShorts)
        {
            if(petShorts.Count > 0)
            {
                var firstPetShort = petShorts.FirstOrDefault();
                firstPetShort.MediaUrl = firstPetShort.Media.MediaUrl;
            }
        }
    }
}
