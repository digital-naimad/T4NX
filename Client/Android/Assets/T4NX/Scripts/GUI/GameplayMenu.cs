using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class GameplayMenu : MonoBehaviour
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

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Decrements gameplay mode options index
        /// </summary>
        public void SwitchOptionUp()
        {
            currentlySelectedOption--;
            if (currentlySelectedOption < 0)
            {
                currentlySelectedOption += (int)GameplayMode.Count;
            }
            //currentlySelectedOption = (GameplayMode)((int)currentlySelectedOption % (int)GameplayMode.Count);
            SelectOption(currentlySelectedOption);
        }

        /// <summary>
        /// Increments gameplay mode options index
        /// </summary>
        public void SwitchOptionDown()
        {
            currentlySelectedOption++;
            currentlySelectedOption = (GameplayMode)((int)currentlySelectedOption % (int)GameplayMode.Count);
            SelectOption(currentlySelectedOption);
        }

        /// <summary>
        /// Helper alias
        /// </summary>
        /// <param name="gameplayMode"></param>
        /// <returns></returns>
        public GameplayModeController GetGameModeController(GameplayMode gameplayMode)
        {
            return gameplayOptions[(int)gameplayMode].Controller;
        }
        

        private void SelectOption(GameplayMode selectedMode)
        {
            for (GameplayMode gameplayOption = 0; gameplayOption < GameplayMode.Count; gameplayOption++)
            {
                gameplayOptions[(int)gameplayOption].Select(selectedMode == gameplayOption);
            }
        }
    }
}
