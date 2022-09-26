using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class TerrainBlock : CustomSprite
    {
        [SerializeField] private TerrainType _terrainType = TerrainType.Empty;



        public TerrainType TerrainBlockType 
        { 
            get 
            {
                return _terrainType;//(TerrainType)material.GetFloat(TerrainBlockReference._TypeID); 
            } 
            set
            {
                _terrainType = value;

                SetFloat(TerrainBlockReference._TypeID, (float)_terrainType);// (float)TerrainBlockType);
                ApplyType();
                //Debug.Log(name + " >> terraintype " + (float)TerrainType + " >> " + TerrainType);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           // if (Random.Range(0, 1000) < 10)
            {
               // SetFloat(TerrainBlockReference._TypeID, (float)(Random.Range((int)TerrainType.Brick, (int)TerrainType.Empty)));
            }
        }

        /// <summary>
        /// Applies terrainType id, sprite color subpalette and also sets FPS, and masks at custom sprite shader
        /// </summary>
        public void ApplyType()
        {
            //Debug.Log(name + " >> ApplyType() " + TerrainBlockType);

            

            //SetFloat(TerrainBlockReference._TypeID, (float)(Random.Range((int)TerrainType.Brick, (int)TerrainType.Empty)));

            ScreenPalette.SpriteSubpalette terrainSubpalette = ScreenPalette.Instance.GetTerrainColors(TerrainBlockType);
            ApplyColors(terrainSubpalette);
            //Debug.Log(">>> color names " + terrainSubpalette.AColorName + " " + terrainSubpalette.BColorName + " " + terrainSubpalette.CColorName);


            //Debug.Log(">>> TerrainBlock type: " + TerrainBlockType);
            switch (TerrainBlockType)
            {
                
                case TerrainType.Brick:
                    FPS = 0;
                    Mask = Vector4.zero;
                    //BaseColor = Color.white;
                    ScreenLayer = ScreenLayers.StageMiddle;
                    break;
                case TerrainType.Bush:
                    FPS = 0;
                    Mask = Vector4.zero;
                    //BaseColor = Color.white;
                    ScreenLayer = ScreenLayers.StageFront;
                    break;
                case TerrainType.Ice:
                    FPS = 0;
                    Mask = Vector4.zero;
                    //BaseColor = Color.white;
                    ScreenLayer = ScreenLayers.StageBackground;
                    break;
                case TerrainType.Steel:
                    FPS = 0;
                    Mask = Vector4.zero;
                   // BaseColor = Color.white;
                    ScreenLayer = ScreenLayers.StageFront;
                    break;
                case TerrainType.Water:
                    FPS = 6;
                    Mask = Vector4.zero;
                    //BaseColor = Color.white;
                    ScreenLayer = ScreenLayers.StageBackground;
                    break;
                case TerrainType.DeepWater:
                    FPS = 6;
                    Mask = Vector4.zero;
                    //BaseColor = Color.white;
                    ScreenLayer = ScreenLayers.StageFront;
                    break;
                case TerrainType.Empty:
                    FPS = 0;
                    Mask = Vector4.one;
                    //BaseColor = Color.white;
                    ScreenLayer = ScreenLayers.StageBackground;
                    break;
                default:

                    
                
                    //Debug.Log(name + " >>> undefined TerrainType");
                    Mask = Vector4.zero;
                    BaseColor = Color.white;
                    ScreenLayer = ScreenLayers.StageBackground;
                    break;
                    
                    


            }

            //this.gameObject.SetActive(false);
            //this.gameObject.SetActive(true);

        }

    }
}
