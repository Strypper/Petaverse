namespace Petaverse.UWP.Core;

public static class SettingsHelper
{
    private static readonly ApplicationDataContainer Settings = ApplicationData.Current.LocalSettings;

    public static void SetValue(string key, object value)
    {
        Settings.Values[key] = value;
    }

    public static object GetValue(string key)
    {
        if (Settings.Values.Any(x => x.Key == key))
        {
            return Settings.Values[key];
        }

        return null;
    }

    public static void CreateSettings()
    {
        if (!Settings.Values.Any(x => x.Key == SettingsConstants.Theme))
        {
            Settings.Values[SettingsConstants.Theme] = 0;
        }
    }
}
