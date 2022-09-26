using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class StageUtils : MonoSingleton<StageUtils>
    {
        //private Dictionary<char, TerrainType> _charToTerrainTypeDictionary = new Dictionary<char, TerrainType>();
        //private Dictionary< TerrainType, char> _terrainTypeToCharDictionary = new Dictionary<TerrainType, char>();

        private void Awake()
        {
            //FillConversionDictionaries();

        }
        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update() 
        {

        }

        /// <summary>
        /// Converts given terrainType into single character
        /// </summary>
        /// <param name="terrainType"></param>
        /// <returns></returns>
         /*
        public static char ConvertTerrainTypeToChar(TerrainType terrainType)
        {
           // if (Instance._terrainTypeToCharDictionary.Count == 0) 
            {
               // FillConversionDictionaries();
            }
            return Instance._terrainTypeToCharDictionary[terrainType];
        }
        */
        /// <summary>
        /// Converts single character given via parameter into terrainType
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        /*
        public static TerrainType ConvertCharToTerrainType(char character)
        {
           // if (Instance._charToTerrainTypeDictionary.Count == 0)
            {
              ///  FillConversionDictionaries();
            }
            return Instance._charToTerrainTypeDictionary[character];
        }
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Vector3: converted from int x, y</returns>
        public static Vector3 ConvertVector2IntTo3(int x, int y)
        {
            return new Vector3(x, y, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns>Vector3: converted Vector2Int </returns>
        public static Vector3 ConvertVector2IntTo3(Vector2Int position)
        {
            return ConvertVector2IntTo3(position.x, position.y);
        }

        /*

        public static TerrainType GetRandomTerrainType()
        {
            return (TerrainType)Random.Range(0, (int)TerrainType.Count);
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quarter"></param>
        /// <returns></returns>
        public static Vector2Int GetQuarterVector2Int(Quarter quarter)
        {
            switch (quarter)
            {
                case Quarter.NorthWest:
                    return new Vector2Int(0, 1);
                case Quarter.NorthEast:
                    return new Vector2Int(1, 1);
                case Quarter.SouthWest:
                    return new Vector2Int(0, 0);
                case Quarter.SouthEast:
                default:
                    return new Vector2Int(1, 0);
            }
           
        }

        #region Private methods
        /*
        private static void FillConversionDictionaries()
        {
            for (BlockShortcut b = 0; b < BlockShortcut.Count; b++)
            {
                AddTerrainTypeChar( (TerrainType)((int)b), b.ToString()[0]);
            }
        }

        private static void AddTerrainTypeChar(TerrainType terrainType, char character)
        {
            Instance._terrainTypeToCharDictionary.Add(terrainType, character);
            Instance._charToTerrainTypeDictionary.Add(character, terrainType);
        }
        */
        #endregion

    }
}
