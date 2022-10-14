using UnityEngine;

namespace T4NX
{

    [System.Serializable]
    public class TankistColorsPreset 
    {
        [SerializeField] private TankistColor _tankistColorOption = TankistColor.Yellow;
        [SerializeField] private ScreenPalette.SpriteSubpalette _tankistColors;

        /// <summary>
        /// 
        /// </summary>
        public TankistColor TankistColorOption { get { return _tankistColorOption; } }
        /// <summary>
        /// 
        /// </summary>
        public ScreenPalette.SpriteSubpalette TankistColors { get { return _tankistColors; } }
    }
}
