using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace T4NX
{ 
    /// <summary>
    /// Implementation of Observer Pattern also using implementation of Singleton Pattern
    /// </summary>
    public class GamepadEventsManager : MonoSingleton<GamepadEventsManager>
    {
        private Dictionary<GamepadEvent, List<Action<short>>> listenersDictionary;

        #region Life-cycle callback

        private void Awake()
        {
            listenersDictionary = new Dictionary<GamepadEvent, List<Action<short>>>();
        }

        #endregion

        /// <summary>
        /// Registers listener for an event of type given in parameter
        /// </summary>
        /// <param name="eventType">One of GamepadEvent defined in GamepadEvent enum</param>
        /// <param name="callbackFunction"></param>
        public void RegisterListener(GamepadEvent eventType, Action<short> callbackFunction)
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
        public void UnregisterListener(GamepadEvent eventType, Action<short> callbackFunction)
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
        public void DispatchEvent(GamepadEvent eventType, short value = 0)
        {
            //Debug.Log(this.name + " >> Call to dispatch event: " + eventType);

            if (!listenersDictionary.ContainsKey(eventType))
            {
                return;
            }

            foreach (Action<short> listener in listenersDictionary[eventType])
            {
                listener(value);
            }
        }

        public static void SetupListeners(IGamepadEventsListener listeners)
        {
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

            //Debug.Log("GamepadEventsManager >> SetupListeners for " + listeners);
        }

        
    }
}