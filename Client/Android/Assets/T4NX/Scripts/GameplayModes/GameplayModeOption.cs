using TMPro;
using UnityEngine;

namespace T4NX
{
    [System.Serializable]
    public class GameplayModeOption
    {
        [SerializeField] private GameplayMode _gameplayMode;

        [SerializeField] private GameplayModeController controller;
        [SerializeField] private TextMeshProUGUI optionLabelText;
        [SerializeField] private TankCursor cursor;

        /// <summary>
        /// 
        /// </summary>
        /// 
        /*
        public GameplayMode GameplayMode 
        { 
            get 
            { 
                return Controller.GameplayType; 
            } 
            set 
            {
                _gameplayMode = value;
                //Controller.SetGameType(value); 
            } 
        }
        */
        public GameplayModeController Controller { get => controller; }
        public TextMeshProUGUI OptionLabelText { get => optionLabelText; }
        public TankCursor Cursor { get => cursor; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSelected"></param>
        public void Select(bool isSelected)
        {
            cursor.gameObject.SetActive(isSelected);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelText"></param>
        public void UpdateLabel(string labelText)
        {
            OptionLabelText.text = labelText;
        }
    }
}