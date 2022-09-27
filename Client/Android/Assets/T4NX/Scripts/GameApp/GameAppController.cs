using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class GameAppController : MonoBehaviour, IGamepadEventsListener
    {
        [SerializeField] private GameplayMenu gameplayMenu;

       

        // Start is called before the first frame update
        void Start()
        {
            //LaunchGame();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void LaunchGame()
        {

            Debug.Log(name + " >> LaunchGame() Option: " + (int)gameplayMenu.CurrentlySelectedGameplayMode + " GameplayMode: " + gameplayMenu.CurrentlySelectedGameplayMode);
            
            gameplayMenu.CurrentGameplayController.SetupGamepadInputListeners();
            /*
            //IGamepadEventsListener listener = gameModes[(int)_currentGameMode].controller.GamepadEventsListener; // % (int)GameType.TwoPlayers
            IGamepadEventsListener listener = gameplayMenu.GetGameModeController(_currentGameMode).GamepadEventsListener;


            SetupGamepadInputListeners(listener);

            switch (_currentGameMode)
            {
                case GameplayMode.Construction:
                    
                    break;

            }
            */
        }
        /*
      private void SetupGamepadInputListeners(IGamepadEventsListener listener)
      {
          GamepadEventsManager.SetupListeners(listener);
      }
      */




        #region Gamepad Events listeners - SELECT & START
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
        #endregion

        #region Gamepad Events listeners - UP & DOWN
        public void OnUpPressed(short data)
        {
            //isUpPressed = true;
        }

        public void OnUpReleased(short data)
        {
            //isUpPressed = false;
        }

        public void OnDownPressed(short data)
        {
            //isDownPressed = true;
        }

        public void OnDownReleased(short data)
        {
            //isDownPressed = false;
        }
        #endregion

        #region Gamepad Events listeners - LEFT & RIGHT
        public void OnLeftPressed(short data)
        {
            //isLeftPressed = true;
        }

        public void OnLeftReleased(short data)
        {
            //isLeftPressed = false;
        }

        public void OnRightPressed(short data)
        {
            //isRightPressed = true;
        }

        public void OnRightReleased(short data)
        {
            //isRightPressed = false;
        }
        #endregion

        #region Gamepad Events listeners - B & A
        public void OnBPressed(short data)
        {
            //isBPressed = true;
        }

        public void OnBReleased(short data)
        {
            //isBPressed = false;
            //Debug.Log(this.name + " >> On B released");
        }

        public void OnAPressed(short data)
        {
            //isAPressed = true;
        }

        public void OnAReleased(short data)
        {
            //isAPressed = false;
            //Debug.Log(this.name + " >> On A released");
        }
        #endregion


    }

}
