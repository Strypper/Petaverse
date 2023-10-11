using System;

namespace Petaverse.UWP.Core;

public partial class BaseModel<T> : ObservableRecipient
{
    [ObservableProperty]
    T id;

    [ObservableProperty]
    DateTime createdOn;

    [ObservableProperty]
    DateTime? lastUpdatedOn;
}
