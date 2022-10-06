using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class SingleplayerModeController : GameplayModeController, IGamepadEventsListener, IGameplayEventsListener
    {
        //private 

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

        public override void Launch()
        {
            
            Debug.Log(name + " Launch()");


        }

        #region Gameplay Events Listeners - PLAYER TANK SPAWN & MOVE
        public void OnPlayerTankSpawn(params int[] data)
        {
            Debug.Log(this.name + " >> OnPlayerTankSpawn");
        }

        public void OnPlayerTankMove(params int[] data)
        {
            Debug.Log(this.name + " >> OnPlayerTankMove");
        }
        #endregion

        #region Gamepad Events listeners - SELECT & START
        public void OnSelectPressed(params int[] data)
        {

        }

        public void OnSelectReleased(params int[] data)
        {

        }

        public void OnStartPressed(params int[] data)
        {

        }

        public void OnStartReleased(params int[] data)
        {

        }
        #endregion

        #region Gamepad Events listeners - UP & DOWN
        public void OnUpPressed(params int[] data)
        {
            //isUpPressed = true;
        }

        public void OnUpReleased(params int[] data)
        {
            //isUpPressed = false;
        }

        public void OnDownPressed(params int[] data)
        {
            //isDownPressed = true;
        }

        public void OnDownReleased(params int[] data)
        {
            //isDownPressed = false;
        }
        #endregion

        #region Gamepad Events listeners - LEFT & RIGHT
        public void OnLeftPressed(params int[] data)
        {
            //isLeftPressed = true;
        }

        public void OnLeftReleased(params int[] data)
        {
            //isLeftPressed = false;
        }

        public void OnRightPressed(params int[] data)
        {
            //isRightPressed = true;
        }

        public void OnRightReleased(params int[] data)
        {
            //isRightPressed = false;
        }
        #endregion

        #region Gamepad Events listeners - B & A
        public void OnBPressed(params int[] data)
        {
            //isBPressed = true;
        }

        public void OnBReleased(params int[] data)
        {
            //isBPressed = false;
            //Debug.Log(this.name + " >> On B released");
        }

        public void OnAPressed(params int[] data)
        {
            //isAPressed = true;
        }

        public void OnAReleased(params int[] data)
        {
            //isAPressed = false;
            //Debug.Log(this.name + " >> On A released");
        }

       
        #endregion


    }
}