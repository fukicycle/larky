namespace View;

public sealed class AppStateContainer
{
    public int CurrentLevel { get; set; } = 1;
    public bool SilentModeNotificationConfirm { get; set; } = false;
}