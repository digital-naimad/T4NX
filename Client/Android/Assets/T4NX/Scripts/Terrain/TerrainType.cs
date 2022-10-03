using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public enum TerrainType
    {
        /// <summary>
        /// * Tanks and bullets cannot pass through this.
        /// * Can be destroyed by being shot four times (two times when offensive power is tier four/max) on the same side.
        /// </summary>
        Brick,

        /// <summary>
        /// * Obfuscates tanks and bullets under it when moving through.
        /// * Caution: tricky to tell where the enemies are; even trickier to tell where their bullets are.
        /// </summary>
        Trees,

        /// <summary>
        /// 
        /// * Tanks can move on it. When you try to stop moving, your tank will slide forward a bit before stopping.
        /// * Caution: obfuscates flying bullets;
        /// </summary>
        Ice,

        /// <summary>
        /// * Stops tanks and bullets completely.
        /// * Can only be destroyed if hit twice on the same side by maximum power level bullets (tier four).
        /// </summary>
        Steel,

        /// <summary>
        /// * Tanks cannot traverse through at all.
        /// * Bullets can fly across.
        /// </summary>
        Water,

        /// <summary>
        /// * Tanks cannot traverse through at all.
        /// * Bullets can fly across.
        /// </summary>
        DeepWater,
        /// <summary>
        /// It is the also a counter of terrain block types;
        /// </summary>
        Empty//,
       
        //Count
    }
}
