using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class GameAppController : MonoSingleton<GameAppController>, IGamepadEventsListener
    {
        [SerializeField] private TitleScreenController titleScreenController;
        [SerializeField] private GameplayMenu gameplayMenu;
       

        #region MonoBehaviour life-cycle methods
        void Start()
        {
            Init();
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
            gameplayMenu.SelectOption(previousMode);
            titleScreenController.ShowWithAnimation();
        }

        #endregion

        #region Gamepad Events listeners - SELECT & START
        public void OnSelectPressed(short data)
        {
            gameplayMenu.SwitchToNextOption();
        }

        public void OnSelectReleased(short data)
        {

        }

        public void OnStartPressed(short data)
        {
            LaunchGameplayMode();
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

        #region Private methods
        private void Init()
        {
            gameplayMenu.SelectOption(0);
            SetupGamepadListenersForTitleScreen();
        }
        private void LaunchGameplayMode()
        {
            Debug.Log(name + " >> LaunchGameplayMode() GameplayMode: " + gameplayMenu.CurrentlySelectedGameplayMode);


            GamepadEventsManager.Instance.SetupListeners(gameplayMenu.CurrentGameplayController.GamepadEventsListener);

            HideTitleScreen();

            gameplayMenu.CurrentGameplayController.Launch();


        }

        private void HideTitleScreen()
        {
            gameplayMenu.UnselectAll();
            titleScreenController.Hide();
        }

        private void SetupGamepadListenersForTitleScreen()
        {
            GamepadEventsManager.Instance.SetupListeners(this);
        }
        #endregion
    }

}
