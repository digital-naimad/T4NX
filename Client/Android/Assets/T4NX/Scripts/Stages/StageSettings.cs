using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class StageSettings 
    {

        [SerializeField] public static Vector2Int DefaultGridSize = new Vector2Int(32, 30);

        [SerializeField] public static Vector2Int SubblockSize = new Vector2Int(8, 8);
        [SerializeField] public static Vector2Int GridOffsetSize = new Vector2Int(0, 232); // TODO: rework

        /// <summary>
        /// Minimum of borders of CONSTRUCTION stage
        /// </summary>
        [SerializeField] public static Vector2Int ConstructionAreaMin = new Vector2Int(16, 16);

        /// <summary>
        /// Maximum of borders of CONSTRUCTION stage
        /// </summary>
        [SerializeField] public static Vector2Int ConstructionAreaMax = new Vector2Int(224, 224);

    }
}