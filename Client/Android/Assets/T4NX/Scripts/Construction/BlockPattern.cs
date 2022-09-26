using System;
using System.Collections.Generic;

namespace T4NX
{
    [Serializable]
    public class BlockPattern 
    {
        private BlockType type;
        private Dictionary<Quarter, TerrainType> pattern;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="terrainTypeNW"></param>
        /// <param name="terrainTypeNE"></param>
        /// <param name="terrainTypeSW"></param>
        /// <param name="terrainTypeSE"></param>
        /// <param name="blockType"></param>
        public BlockPattern(TerrainType terrainTypeNW = TerrainType.Empty, TerrainType terrainTypeNE = TerrainType.Empty, TerrainType terrainTypeSW = TerrainType.Empty, TerrainType terrainTypeSE = TerrainType.Empty, BlockType blockType = BlockType.Empty)
        {
            type = blockType;

            pattern = new Dictionary<Quarter, TerrainType>();

            pattern.Add(Quarter.NorthWest, terrainTypeNW);
            pattern.Add(Quarter.NorthEast, terrainTypeNE);
            pattern.Add(Quarter.SouthWest, terrainTypeSW);
            pattern.Add(Quarter.SouthEast, terrainTypeSE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quarter"></param>
        /// <returns></returns>
        public TerrainType GetTerrainTypeAt(Quarter quarter)
        {
            return pattern[quarter];
        }

        #region A static class members
        private static Dictionary<BlockType, BlockPattern> patternDictionary = new Dictionary<BlockType, BlockPattern>();

        /// <summary>
        /// 
        /// </summary>
        public static void FillPatternsDictionary()
        {
            patternDictionary.Clear();

            patternDictionary.Add(BlockType.Empty, new BlockPattern());

            // Brick sides
            patternDictionary.Add(BlockType.BrickEast, new BlockPattern(TerrainType.Empty, TerrainType.Brick, TerrainType.Empty, TerrainType.Brick, BlockType.BrickEast));
            patternDictionary.Add(BlockType.BrickSouth, new BlockPattern(TerrainType.Empty, TerrainType.Empty, TerrainType.Brick, TerrainType.Brick, BlockType.BrickSouth));
            patternDictionary.Add(BlockType.BrickWest, new BlockPattern(TerrainType.Brick, TerrainType.Empty, TerrainType.Brick, TerrainType.Empty, BlockType.BrickWest));
            patternDictionary.Add(BlockType.BrickNorth, new BlockPattern(TerrainType.Brick, TerrainType.Brick, TerrainType.Empty, TerrainType.Empty, BlockType.BrickNorth));

            // Brick full
            patternDictionary.Add(BlockType.BrickFull, new BlockPattern(TerrainType.Brick, TerrainType.Brick, TerrainType.Brick, TerrainType.Brick, BlockType.BrickFull));

            // Steel sides
            patternDictionary.Add(BlockType.SteelEast, new BlockPattern(TerrainType.Empty, TerrainType.Steel, TerrainType.Empty, TerrainType.Steel, BlockType.SteelEast));
            patternDictionary.Add(BlockType.SteelSouth, new BlockPattern(TerrainType.Empty, TerrainType.Empty, TerrainType.Steel, TerrainType.Steel, BlockType.SteelSouth));
            patternDictionary.Add(BlockType.SteelWest, new BlockPattern(TerrainType.Steel, TerrainType.Empty, TerrainType.Steel, TerrainType.Empty, BlockType.SteelWest));
            patternDictionary.Add(BlockType.SteelNorth, new BlockPattern(TerrainType.Steel, TerrainType.Steel, TerrainType.Empty, TerrainType.Empty, BlockType.SteelNorth));

            // Steel full
            patternDictionary.Add(BlockType.SteelFull, new BlockPattern(TerrainType.Steel, TerrainType.Steel, TerrainType.Steel, TerrainType.Steel, BlockType.SteelFull));

            // Water full
            patternDictionary.Add(BlockType.WaterFull, new BlockPattern(TerrainType.Water, TerrainType.Water, TerrainType.Water, TerrainType.Water, BlockType.WaterFull));

            // Bush full
            patternDictionary.Add(BlockType.BushFull, new BlockPattern(TerrainType.Bush, TerrainType.Bush, TerrainType.Bush, TerrainType.Bush, BlockType.BushFull));

            // Ice full
            patternDictionary.Add(BlockType.IceFull, new BlockPattern(TerrainType.Ice, TerrainType.Ice, TerrainType.Ice, TerrainType.Ice, BlockType.IceFull));

            // Bricks quarters
            patternDictionary.Add(BlockType.BrickSouthEast, new BlockPattern(TerrainType.Empty, TerrainType.Empty, TerrainType.Empty, TerrainType.Brick, BlockType.BrickSouthEast));
            patternDictionary.Add(BlockType.BrickSouthWest, new BlockPattern(TerrainType.Empty, TerrainType.Empty, TerrainType.Brick, TerrainType.Empty, BlockType.BrickSouthWest));
            patternDictionary.Add(BlockType.BrickNorthEast, new BlockPattern(TerrainType.Empty, TerrainType.Brick, TerrainType.Empty, TerrainType.Empty, BlockType.BrickNorthEast));
            patternDictionary.Add(BlockType.BrickNorthWest, new BlockPattern(TerrainType.Brick, TerrainType.Empty, TerrainType.Empty, TerrainType.Empty, BlockType.BrickNorthWest));

            // Steel quarters
            patternDictionary.Add(BlockType.SteelSouthEast, new BlockPattern(TerrainType.Empty, TerrainType.Empty, TerrainType.Empty, TerrainType.Steel, BlockType.SteelSouthEast));
            patternDictionary.Add(BlockType.SteelSouthWest, new BlockPattern(TerrainType.Empty, TerrainType.Empty, TerrainType.Steel, TerrainType.Empty, BlockType.SteelSouthWest));
            patternDictionary.Add(BlockType.SteelNorthEast, new BlockPattern(TerrainType.Empty, TerrainType.Steel, TerrainType.Empty, TerrainType.Empty, BlockType.SteelNorthEast));
            patternDictionary.Add(BlockType.SteelNorthWest, new BlockPattern(TerrainType.Steel, TerrainType.Empty, TerrainType.Empty, TerrainType.Empty, BlockType.SteelNorthWest));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockType"></param>
        /// <returns></returns>
        public static BlockPattern GetPattern(BlockType blockType)
        {
            return patternDictionary[blockType];
        }
        #endregion
    }
}