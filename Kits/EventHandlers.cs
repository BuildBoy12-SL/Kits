namespace Kits
{
    public class EventHandlers
    {
        public void OnRestartingRound()
        {
            MainClass.singleton.OneTimePerRound = true;
        }
    }
}
