﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Petaverse.UWP.Core;

public partial class Species : BaseModel<string>
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
    List<Breed> breeds = new();
}
