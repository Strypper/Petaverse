using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PetaVerse.Models.DTOs
{
    public partial class Species : BaseEntity
    {
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string icon;
        [ObservableProperty]
        string color;
        [ObservableProperty]
        string description;
        [ObservableProperty]
        string topLovedPetOfTheWeek;

        [ObservableProperty]
        ObservableCollection<Breed> breeds;
    }
}
