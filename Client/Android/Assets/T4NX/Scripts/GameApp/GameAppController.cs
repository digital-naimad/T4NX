using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class GameAppController : MonoSingleton<GameAppController>, IGamepadEventsListener
    {
        //[SerializeField] private TitleScreenController titleScreenController;
        //[SerializeField] private GameplayMenu gameplayMenu;
       

        #region MonoBehaviour life-cycle methods
        void Start()
        {
            LaunchGame();

        }


        void Update()
        {

        }
        #endregion

        #region Public methods
        public void ReturnToTitleScreen(GameplayMode previousMode)
        {
            Debug.Log(name + " >> ReturnToTitleScreen()");

            SetupGamepadListenersForTitleScreen();

            GameplayMenu.Instance.SelectOption(previousMode);

            TitleScreenController.Instance.Show();
        }

        #endregion

        #region Gamepad Events listeners - SELECT & START
        public void OnSelectPressed(short data)
        {
            if (!ScreenShifter.Instance.IsShiftEnded)
            {
                ScreenShifter.Instance.ForceEnd();
            }
            else 
            {
                GameplayMenu.Instance.SwitchToNextOption();
            }
            
        }

        public void OnSelectReleased(short data)
        {

        }

        public void OnStartPressed(short data)
        {
            if (!ScreenShifter.Instance.IsShiftEnded)
            {
                ScreenShifter.Instance.ForceEnd();
            }
            else
            {
                HideTitleScreen();
                LaunchStageSelector();
            }
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

            //ScreenFader.Instance.Close();
        }

        public void OnBReleased(short data)
        {
            
            //isBPressed = false;
            //Debug.Log(this.name + " >> On B released");
        }

        public void OnAPressed(short data)
        {
            //ScreenFader.Instance.Open();
            //isAPressed = true;
        }

        public void OnAReleased(short data)
        {
            //isAPressed = false;
            //Debug.Log(this.name + " >> On A released");
        }
        #endregion

        #region Private methods
        private void LaunchGame()
        {
            SetupGamepadListenersForTitleScreen();
            ScreenShifter.Instance.MoveIn(InitTitleScreen);
          
        }

        private void InitTitleScreen()
        {
            GameplayMenu.Instance.SelectOption(0);
        }

        private void LaunchStageSelector()
        {
            Debug.Log(name + " LaunchStageSelector()");
            StageSelector.Instance.Launch();
        }

      

        private void HideTitleScreen()
        {
            Debug.Log(name + " HideTitleScreen()");
            GameplayMenu.Instance.UnselectAll();
            TitleScreenController.Instance.Hide();
        }

        private void SetupGamepadListenersForTitleScreen()
        {
            GamepadEventsManager.Instance.SetupListeners(this);
        }
        #endregion
    }

}
