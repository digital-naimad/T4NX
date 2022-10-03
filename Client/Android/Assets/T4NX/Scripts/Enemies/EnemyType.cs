using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public enum EnemyType 
    {
        /// <summary>
        /// Points: 100;
        /// Movement: 1 (Slow);
        /// Bullet: 1 (Slow);
        /// * Generally poses little threat. Moves slower than players, fires at the same speed default power level (zero stars).
        /// </summary>
        BasicTank,

        /// <summary>
        /// Points: 200;
        /// Movement: 3 (Fast);
        /// Bullet: 2 (Normal);
        /// * Generally more dangerous to the headquarters than a player; should be dispatched quickly.
        /// </summary>
        FastTank,

        /// <summary>
        /// Points: 300;
        /// Movement: 2 (Normal);
        /// Bullet: 3 (Fast);
        /// * Don't go to their line of fire.
        /// * Cuts through Brick Walls quicker than other tanks (notable in Stage 34).
        /// </summary>
        PowerTank,

        /// <summary>
        /// Points: 400;
        /// Movement: 2 (Normal);
        /// Bullet: 2 (Normal);
        /// * Start as green; gradually turns gray upon harm.
        /// * Don't destroy them head-on until the 2nd Star powerup is collected.
        /// </summary>
        ArmorTank,
        /// <summary>
        /// Just a counter of Enemies types
        /// </summary>
        TypeCount
    }
}
