using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class ScreenPalette : MonoSingleton<ScreenPalette>   
    {
        [System.Serializable]
        public struct SpriteSubpalette
        {
            public string colorName;
            public ColorName baseColorName;
            public ColorName AColorName;
            public ColorName BColorName;
            public ColorName CColorName;
        }

        [SerializeField] private ScreenPaletteData screenPaletteData;

        [SerializeField] private List<SpriteSubpalette> terrainPalettes = new List<SpriteSubpalette>();
       
        [SerializeField] private Color screenAmbientColor = Color.white;

        #region MonoBehaviour stuff
        private void Awake()
        {
            SetupLightning();
        }
        /*
       // Start is called before the first frame update
       void Start()
       {



       }

       // Update is called once per frame
       void Update()
       {
           //SetupLightning();

       }
       */
        #endregion

        #region Public methods - GETTERS
        public Color GetColor(ColorName colorName)
        {
            //Debug.Log("Color number: " + (int)colorName);
            return screenPaletteData.GetColor((int)colorName);
        }

        public SpriteSubpalette GetTerrainColors(TerrainType terrainType)
        {
            //Debug.Log(">> terrain subpalette type: " + terrainType);
            return terrainPalettes[(int)terrainType];//terrainPalettes[Mathf.Clamp((int)terrainType, 0, terrainPalettes.Count) ];
        }
        #endregion

        #region Private methods

        private void SetupLightning()
        {
            RenderSettings.ambientLight = screenAmbientColor;
        }
        #endregion
    }
}
