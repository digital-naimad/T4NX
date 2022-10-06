using System;
using System.Collections.Generic;

namespace T4NX
{
    /// <summary>
    /// Implementation of Observer Pattern also using implementation of Singleton Pattern
    /// </summary>
    /// <typeparam name="CustomEvent">GamepadEvent or GameplayEvent enum</typeparam>
    /// <typeparam name="CustomListenerInterface">IGamepadEventsListener or IGameplayEventsListener interface</typeparam>
    public class EventsManager<CustomEvent, CustomListenerInterface> : MonoSingleton<GamepadEventsManager>
    {
        protected Dictionary<CustomEvent, List<Action<short>>> listenersDictionary = new Dictionary<CustomEvent, List<Action<short>>>();
        protected CustomListenerInterface currentListeners; // = null;

        #region Life-cycle callback
        private void Awake()
        {

        }

        #endregion

        #region Public methods
        /// <summary>
        /// Registers listener for an event of type given in parameter
        /// </summary>
        /// <param name="eventType">One of GamepadEvent defined in GamepadEvent enum</param>
        /// <param name="callbackFunction"></param>
        public void RegisterListener(CustomEvent eventType, Action<short> callbackFunction)
        {
            if (!listenersDictionary.ContainsKey(eventType))
            {
                listenersDictionary.Add(eventType, new List<Action<short>>());
            }

            listenersDictionary[eventType].Add(callbackFunction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType">One of GamepadEvents defined in GamepadEvent enum</param>
        /// <param name="callbackFunction"></param>
        public void UnregisterListener(CustomEvent eventType, Action<short> callbackFunction)
        {
            if (!listenersDictionary.ContainsKey(eventType))
            {
                return;
            }

            if (!listenersDictionary[eventType].Contains(callbackFunction))
            {
                return;
            }

            listenersDictionary[eventType].Remove(callbackFunction);
        }

        /// <summary>
        /// Callbacks all of registered listeners about occurrence of an event given in the first parameter
        /// </summary>
        /// <param name="eventType">One of a GamepadEvents defined in GamepadEvent enum</param>
        /// <param name="value">optional value of type short. Using by some eventTypes</param>
        public void DispatchEvent(CustomEvent eventType, short value = 0)
        {
            //Debug.Log(this.name + " >> Call to dispatch event: " + eventType);

            if (!listenersDictionary.ContainsKey(eventType))
            {
                return;
            }

            /* OLD
            foreach (Action<short> listener in listenersDictionary[eventType])
            {
                listener(value);
            }
            */

            List<Action<short>> actionsList = listenersDictionary[eventType];//.ForEach(e => e(value));
            //actionsList.ForEach(e => e(value));

            for (int i = 0; i < actionsList.Count; i++)
            {
                actionsList[i].Invoke(value);
            }

        }
        #endregion
    }
}