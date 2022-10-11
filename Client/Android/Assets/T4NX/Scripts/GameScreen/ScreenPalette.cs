using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static T4NX.ScreenPalette;

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

        [SerializeField] private ScreenPaletteScriptableObject screenPaletteScriptableObject;

        [SerializeField] private List<SpriteSubpalette> terrainPalettes = new List<SpriteSubpalette>();
        [SerializeField] private List<SpriteSubpalette> tankersPalettes = new List<SpriteSubpalette>();

        [SerializeField] private Color screenAmbientColor = Color.white;

        private void Awake()
        {
            SetupLightning();
        }

        // Start is called before the first frame update
        void Start()
        {
            
            
          
        }

        // Update is called once per frame
        void Update()
        {
            //SetupLightning();

        }

        public Color GetColor(ColorName colorName)
        {
            //Debug.Log("Color number: " + (int)colorName);
            return screenPaletteScriptableObject.GetColor((int)colorName);
        }

        public SpriteSubpalette GetTerrainColors(TerrainType terrainType)
        {
            //Debug.Log(">> terrain subpalette type: " + terrainType);
            return terrainPalettes[(int)terrainType];//terrainPalettes[Mathf.Clamp((int)terrainType, 0, terrainPalettes.Count) ];
        }

        public SpriteSubpalette GetTankerColors(TankistColor colorOption)
        {
            Debug.Log(">> tanker subpalette option: " + colorOption);
            return tankersPalettes[(int)colorOption % tankersPalettes.Count];
        }

        private void SetupLightning()
        {
            RenderSettings.ambientLight = screenAmbientColor;
        }

    }
}
