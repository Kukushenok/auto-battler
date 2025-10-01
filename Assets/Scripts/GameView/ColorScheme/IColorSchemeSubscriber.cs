namespace Game.View.ColorScheme
{
    /// <summary>
    /// yeah I should have definitely go the R3 way
    /// but... nah I don't want to install NuGet for Unity
    /// for only one thing
    /// </summary>
    public interface IColorSchemeSubscriber
    {
        public void SetColorScheme(ColorScheme scheme, bool firstTime = false);
    }
}
