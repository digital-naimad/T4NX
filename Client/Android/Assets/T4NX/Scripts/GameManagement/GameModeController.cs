using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class GameModeController : MonoBehaviour
    {
        [SerializeField] protected GameType _gameType;

        public GameType GameType { get { return _gameType; } }
        public IGamepadEventsListener GamepadEventsListener { get { return _gamepadEventsListener; } }

        protected IGamepadEventsListener _gamepadEventsListener;
    }
}
