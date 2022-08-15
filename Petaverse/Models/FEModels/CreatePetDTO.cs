using CommunityToolkit.Mvvm.ComponentModel;
using System;
using Windows.Storage;

namespace Petaverse.Models.FEModels
{
    public partial class CreatePetDTO : ObservableRecipient
    {
        [ObservableProperty]
        int age;
        [ObservableProperty]
        string bio;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        bool gender;
        [ObservableProperty]
        int breedId;
        [ObservableProperty]
        int speciesId;
        [ObservableProperty]
        string petColor;
        [ObservableProperty]
        string ownerGuids;
        [ObservableProperty]
        DateTime dateOfBirth;
        [ObservableProperty]
        StorageFile petAvatar;

    }
}
