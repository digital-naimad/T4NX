using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

namespace T4NX
{
    public class GameplayMenu : MonoSingleton<GameplayMenu>
    {
        [SerializeField] private GameplayMode currentlySelectedOption = GameplayMode.Singleplayer;

        [SerializeField] private List<GameplayModeOption> gameplayOptions = new List<GameplayModeOption>();


        /// <summary>
        /// 
        /// </summary>
        public GameplayModeController CurrentGameplayController 
        { 
            get 
            {
                return GetGameModeController(currentlySelectedOption);
            } 
        }

        public GameplayMode CurrentlySelectedGameplayMode { get => currentlySelectedOption; }

        #region MonoBehaviour's callbacks

        private void Awake()
        {
            UnselectAll();    
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }
        #endregion

        #region Public methods >> Switching between Gameplay Options

        /// <summary>
        /// Decrements gameplay mode options index and selects current GameplayModeOption
        /// </summary>
        public void SwitchToPreviousOption()
        {
            currentlySelectedOption--;
            if (currentlySelectedOption < 0)
            {
                currentlySelectedOption = GameplayMode.Count - 1;
            }
            SelectOption(currentlySelectedOption);
        }

        /// <summary>
        /// Increments gameplay mode options index and selects current GameplayModeOption
        /// </summary>
        public void SwitchToNextOption()
        {
            currentlySelectedOption++;
            currentlySelectedOption = (GameplayMode)((int)currentlySelectedOption % (int)GameplayMode.Count);
            SelectOption(currentlySelectedOption);
        }
        #endregion

        #region Public methods >> Changing Tankist Profile

        /// <summary>
        /// Refreshes colors of Tank coursors
        /// </summary>
        public void UpdateTankistAvatar(ScreenPalette.SpriteSubpalette tankistColors)
        {

            for (GameplayMode gameplayOption = 0; gameplayOption < GameplayMode.Count; gameplayOption++)
            {
                gameplayOptions[(int)gameplayOption].UpdateCursorColors(tankistColors);
            }
        }


        /// <summary>
        /// Refreshes the text of Takist Name label with name given in the parameter
        /// </summary>
        public void UpdateTankistName(string tankistName)
        {
            gameplayOptions[0].UpdateTankistNameLabel(tankistName);
        }


        #endregion

        #region Public methods >> 

        /// <summary>
        /// Helper alias
        /// </summary>
        /// <param name="gameplayMode"></param>
        /// <returns></returns>
        public GameplayModeController GetGameModeController(GameplayMode gameplayMode)
        {
            return gameplayOptions[(int)gameplayMode].Controller;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedMode">optional, default value is 0</param>
        public void SelectOption(GameplayMode selectedMode = 0)
        {
            for (GameplayMode gameplayOption = 0; gameplayOption < GameplayMode.Count; gameplayOption++)
            {
                gameplayOptions[(int)gameplayOption].Select(selectedMode == gameplayOption);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void UnselectAll()
        {
            for (GameplayMode gameplayOption = 0; gameplayOption < GameplayMode.Count; gameplayOption++)
            {
                gameplayOptions[(int)gameplayOption].Select(false);
            }
        }
        #endregion
    }
}
