
namespace T4NX
{ 
    /// <summary>
    /// Implementation of Observer Pattern also using implementation of Singleton Pattern
    /// </summary>
    public class GamepadEventsManager : EventsManager<GamepadEvent, IGamepadEventsListener>//MonoSingleton<GamepadEventsManager>
    {
        //private Dictionary<GamepadEvent, List<Action<short>>> listenersDictionary = new Dictionary<GamepadEvent, List<Action<short>>>();
        //private IGamepadEventsListener currentListeners = null;


        public void SetupListeners(IGamepadEventsListener listeners)
        {
            RemoveListeners();

            currentListeners = listeners;

            // UP & DOWN
            RegisterListener(GamepadEvent.Up_Pressed, listeners.OnUpPressed);
            RegisterListener(GamepadEvent.Up_Released, listeners.OnUpReleased);

            RegisterListener(GamepadEvent.Down_Pressed, listeners.OnDownPressed);
            RegisterListener(GamepadEvent.Down_Released, listeners.OnDownReleased);

            // LEFT & RIGHT
            RegisterListener(GamepadEvent.Left_Pressed, listeners.OnLeftPressed);
            RegisterListener(GamepadEvent.Left_Released, listeners.OnLeftReleased);

            RegisterListener(GamepadEvent.Right_Pressed, listeners.OnRightPressed);
            RegisterListener(GamepadEvent.Right_Released, listeners.OnRightReleased);

            // SELECT & START
            RegisterListener(GamepadEvent.Select_Pressed, listeners.OnSelectPressed);
            RegisterListener(GamepadEvent.Select_Released, listeners.OnSelectReleased);

            RegisterListener(GamepadEvent.Start_Pressed, listeners.OnStartPressed);
            RegisterListener(GamepadEvent.Start_Released, listeners.OnStartReleased);

            // B & A
            RegisterListener(GamepadEvent.B_Pressed, listeners.OnBPressed);
            RegisterListener(GamepadEvent.B_Released, listeners.OnBReleased);

            RegisterListener(GamepadEvent.A_Pressed, listeners.OnAPressed);
            RegisterListener(GamepadEvent.A_Released, listeners.OnAReleased);

            /*
            // UP & DOWN
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Up_Pressed, listeners.OnUpPressed);
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Up_Released, listeners.OnUpReleased);

            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Down_Pressed, listeners.OnDownPressed);
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Down_Released, listeners.OnDownReleased);

            // LEFT & RIGHT
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Left_Pressed, listeners.OnLeftPressed);
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Left_Released, listeners.OnLeftReleased);

            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Right_Pressed, listeners.OnRightPressed);
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Right_Released, listeners.OnRightReleased);

            // SELECT & START
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Select_Pressed, listeners.OnSelectPressed);
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Select_Released, listeners.OnSelectReleased);

            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Start_Pressed, listeners.OnStartPressed);
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.Start_Released, listeners.OnStartReleased);

            // B & A
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.B_Pressed, listeners.OnBPressed);
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.B_Released, listeners.OnBReleased);

            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.A_Pressed, listeners.OnAPressed);
            GamepadEventsManager.Instance.RegisterListener(GamepadEvent.A_Released, listeners.OnAReleased);
            */
            //Debug.Log("GamepadEventsManager >> SetupListeners for " + listeners);
        }

        private void ClearDictionary()
        {

        }

        
        private void RemoveListeners()
        {
            if (currentListeners == null)
            { 
                return;
            }
            /*
            // UP & DOWN
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Up_Pressed, currentListeners.OnUpPressed);
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Up_Released, currentListeners.OnUpReleased);

            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Down_Pressed, currentListeners.OnDownPressed);
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Down_Released, currentListeners.OnDownReleased);

            // LEFT & RIGHT
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Left_Pressed, currentListeners.OnLeftPressed);
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Left_Released, currentListeners.OnLeftReleased);

            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Right_Pressed, currentListeners.OnRightPressed);
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Right_Released, currentListeners.OnRightReleased);

            // SELECT & START
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Select_Pressed, currentListeners.OnSelectPressed);
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Select_Released, currentListeners.OnSelectReleased);

            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Start_Pressed, currentListeners.OnStartPressed);
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.Start_Released, currentListeners.OnStartReleased);

            // B & A
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.B_Pressed, currentListeners.OnBPressed);
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.B_Released, currentListeners.OnBReleased);

            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.A_Pressed, currentListeners.OnAPressed);
            GamepadEventsManager.Instance.UnregisterListener(GamepadEvent.A_Released, currentListeners.OnAReleased);
            */

            // UP & DOWN
            UnregisterListener(GamepadEvent.Up_Pressed, currentListeners.OnUpPressed);
            UnregisterListener(GamepadEvent.Up_Released, currentListeners.OnUpReleased);

            UnregisterListener(GamepadEvent.Down_Pressed, currentListeners.OnDownPressed);
            UnregisterListener(GamepadEvent.Down_Released, currentListeners.OnDownReleased);

            // LEFT & RIGHT
            UnregisterListener(GamepadEvent.Left_Pressed, currentListeners.OnLeftPressed);
            UnregisterListener(GamepadEvent.Left_Released, currentListeners.OnLeftReleased);

            UnregisterListener(GamepadEvent.Right_Pressed, currentListeners.OnRightPressed);
            UnregisterListener(GamepadEvent.Right_Released, currentListeners.OnRightReleased);

            // SELECT & START
            UnregisterListener(GamepadEvent.Select_Pressed, currentListeners.OnSelectPressed);
            UnregisterListener(GamepadEvent.Select_Released, currentListeners.OnSelectReleased);

            UnregisterListener(GamepadEvent.Start_Pressed, currentListeners.OnStartPressed);
            UnregisterListener(GamepadEvent.Start_Released, currentListeners.OnStartReleased);

            // B & A
            UnregisterListener(GamepadEvent.B_Pressed, currentListeners.OnBPressed);
            UnregisterListener(GamepadEvent.B_Released, currentListeners.OnBReleased);

            UnregisterListener(GamepadEvent.A_Pressed, currentListeners.OnAPressed);
            UnregisterListener(GamepadEvent.A_Released, currentListeners.OnAReleased);
        }
        
    }
}