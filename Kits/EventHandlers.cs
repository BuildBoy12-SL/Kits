namespace Kits
{
    public class EventHandlers
    {
        public void OnRestartingRound()
        {
            Checker.OneTimePerRound = true;
        }
    }
}
