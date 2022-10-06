
namespace T4NX
{
    /// <summary>
    /// Implementation of Observer Pattern also using implementation of Singleton Pattern
    /// </summary>
    public class GameplayEventsManager : EventsManager<GameplayEvent, IGameplayEventsListener>
    {
        public void SetupListeners(IGameplayEventsListener listeners)
        {
            RemoveListeners();

            currentListeners = listeners;

            // PLAYER TANK SPAWN
            RegisterListener(GameplayEvent.PlayerTankSpawn, listeners.OnPlayerTankSpawn);

            // PLAYER TANK MOVE
            RegisterListener(GameplayEvent.PlayerTankMove, listeners.OnPlayerTankMove);
        }

        private void RemoveListeners()
        {
            if (currentListeners == null)
            {
                return;
            }

            // PLAYER TANK SPAWN
            UnregisterListener(GameplayEvent.PlayerTankSpawn, currentListeners.OnPlayerTankSpawn);

            // PLAYER TANK MOVE
            UnregisterListener(GameplayEvent.PlayerTankMove, currentListeners.OnPlayerTankMove);
        }
    }
}