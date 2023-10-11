using System;

namespace Petaverse.UWP.Contracts;

public class BaseReturnType
{
    public bool IsSuccess { get; set; }
    public string? Note { get; set; }
    public string? ReasonFailed { get; set; }
    public TimeSpan Duration { get; set; }
}
