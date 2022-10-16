using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    [CreateAssetMenu(fileName = "ScreenPalette", menuName = "Palettes/Palette", order = 1)]
    public class ScreenPaletteData : ScriptableObject
    {
        public string name;
        
        [SerializeField] private List<Color> colors = new List<Color>();

        
        public void AddToPalette(Color newColor)
        {
            
        }

        public void ClearColorList()
        {
            colors.Clear();
        }

        /// <summary>
        /// "indexInPalette" - warning: for NES palette  count is 55
        /// </summary>
        /// <param name="indexInPalette"> </param>
        /// <returns></returns>
        public Color GetColor(int indexInPalette)
        {
            return colors[indexInPalette];//colors[indexInPalette%colors.Count];
        }
    }
}