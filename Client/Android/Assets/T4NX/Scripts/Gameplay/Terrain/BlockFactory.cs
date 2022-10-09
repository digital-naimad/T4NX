using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class BlockFactory : MonoSingleton<BlockFactory>
    {
        public const PoolTag TerrainSubblockPoolTag = PoolTag.TerrainSubblock;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        
       /// <summary>

       /// </summary>
       /// <param name="blockType"></param>
       /// <returns></returns>
        public TerrainBlock CreateTerrainBlock(TerrainType terrainBlockType)
        {
            GameObject gameObject = ObjectPooler.Instance.SpawnFromPool(TerrainSubblockPoolTag);   
            TerrainBlock block = gameObject.GetComponentInChildren<TerrainBlock>();
            block.TerrainBlockType = terrainBlockType;
            //block.ApplyType();

            /*
           switch (block.TerrainType)
           {
               case TerrainType.Brick:

                   break;
               case TerrainType.Bush:

                   break;
               case TerrainType.Ice:

                   break;
               case TerrainType.Steel:

                   break;
               case TerrainType.Water:

                   break;
               case TerrainType.DeepWater:

                   break;
               case TerrainType.Empty:

                   break;

           }
           */


            return block;
        }
    }
}
