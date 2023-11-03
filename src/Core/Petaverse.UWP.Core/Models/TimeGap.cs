namespace Petaverse.UWP.Core;

public class TimeGap
{
    public int TimeAmount { get; set; }
    public TimeGapType Type { get; set; }

    public TimeGap(int timeAmount, TimeGapType type)
    {
        this.TimeAmount = timeAmount;
        this.Type = type;
    }
}