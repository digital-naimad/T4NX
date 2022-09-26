using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class GameplayController : GameModeController, IGamepadEventsListener
    {

        private void Awake()
        {
            this._gamepadEventsListener = this;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        #region Gamepad Events listeners
        public void OnAPressed(short data)
        {
            Debug.Log(this.name + " >> On A Pressed");
        }

        public void OnAReleased(short data)
        {
            Debug.Log(this.name + " >> On A released");
        }

        public void OnBPressed(short data)
        {
            Debug.Log(this.name + " >> On B Pressed");
        }

        public void OnBReleased(short data)
        {
            Debug.Log(this.name + " >> On B released");
        }

        public void OnDownPressed(short data)
        {

        }

        public void OnDownReleased(short data)
        {

        }

        public void OnLeftPressed(short data)
        {

        }

        public void OnLeftReleased(short data)
        {

        }

        public void OnRightPressed(short data)
        {

        }

        public void OnRightReleased(short data)
        {

        }

        public void OnSelectPressed(short data)
        {

        }

        public void OnSelectReleased(short data)
        {

        }

        public void OnStartPressed(short data)
        {

        }

        public void OnStartReleased(short data)
        {

        }

        public void OnUpPressed(short data)
        {

        }

        public void OnUpReleased(short data)
        {

        }
        #endregion
    }
}