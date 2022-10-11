using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class GameAppController : MonoSingleton<GameAppController>, IGamepadEventsListener
    {
        //[SerializeField] private TitleScreenController titleScreenController;
        //[SerializeField] private GameplayMenu gameplayMenu;
        [SerializeField] private Transform guiScreenRoot;
       

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


        /// <summary>
        /// Starts currently selected gameplay mode
        /// </summary>
        public void LaunchSelectedGameplayMode()
        {
            Debug.Log(name + " >> LaunchGameplayMode() GameplayMode: " + GameplayMenu.Instance.CurrentlySelectedGameplayMode);

            ScreenFader.Instance.ShowCoverFrame();

            //((GamepadEventsManager)GamepadEventsManager.Instance).SetupListeners(GameplayMenu.Instance.CurrentGameplayController.GamepadEventsListener);
            GamepadEventsManager.SetupListeners(GameplayMenu.Instance.CurrentGameplayController.GamepadEventsListener);

            GameplayMenu.Instance.CurrentGameplayController.Launch();
        }

        #endregion

        #region Gamepad Events listeners - SELECT & START
        public void OnSelectPressed(params int[] data)
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

        public void OnSelectReleased(params int[] data)
        {

        }

        public void OnStartPressed(params int[] data)
        {
            if (!ScreenShifter.Instance.IsShiftEnded)
            {
                ScreenShifter.Instance.ForceEnd();
            }
            else
            {
                HideTitleScreen();
                if (GameplayMenu.Instance.CurrentlySelectedGameplayMode == GameplayMode.StageEditor)
                {
                    LaunchSelectedGameplayMode();
                }
                else
                {
                    LaunchStageSelector();
                }
                
            }
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

            //ScreenFader.Instance.Close();
        }

        public void OnBReleased(params int[] data)
        {
            
            //isBPressed = false;
            //Debug.Log(this.name + " >> On B released");
        }

        public void OnAPressed(params int[] data)
        {
            //ScreenFader.Instance.Open();
            //isAPressed = true;
        }

        public void OnAReleased(params int[] data)
        {
            //isAPressed = false;
            //Debug.Log(this.name + " >> On A released");
        }
        #endregion

        #region Private methods
        private void LaunchGame()
        {
            guiScreenRoot.gameObject.SetActive(true); // just in case

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
            //((GamepadEventsManager)GamepadEventsManager.Instance).SetupListeners(this);
            GamepadEventsManager.SetupListeners(this);
        }
        #endregion
    }

}
