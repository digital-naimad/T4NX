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

        #region Public access
        public GameplayModeController Controller { get => controller; }
        public TextMeshProUGUI OptionLabelText { get => optionLabelText; }
        public TankCursor Cursor { get => cursor; }
        #endregion

        #region Public methods 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSelected"></param>
        public void Select(bool isSelected)
        {
            cursor.GetComponentInChildren<SpriteRenderer>().enabled = isSelected;
        }

        /// <summary>
        /// Sets text given by parameter in place of "1 PLAYER" text
        /// </summary>
        /// <param name="tankistName"></param>
        public void UpdateTankistNameLabel(string tankistName)
        {
            OptionLabelText.text = tankistName;
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateCursorColors(ScreenPalette.SpriteSubpalette spriteSubpalette)
        {
            Cursor.ApplyBaseColors(spriteSubpalette);
        }

        #endregion
    }
}