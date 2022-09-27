using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class GameplayModeController : MonoBehaviour
    {
        //[SerializeField] protected GameplayMode _gameplayMode;

        /// <summary>
        /// Return GameplayMode
        /// </summary>
        //public GameplayMode GameplayType { get { return _gameplayMode; } }
        public IGamepadEventsListener GamepadEventsListener { get { return _gamepadEventsListener; } }

        protected IGamepadEventsListener _gamepadEventsListener;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameplayMode"></param>
        public void SetGameType(GameplayMode gameplayMode)
        {
            //_gameplayMode = gameplayMode;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetupGamepadInputListeners()
        {
            GamepadEventsManager.SetupListeners(GamepadEventsListener);
        }
    }
}
