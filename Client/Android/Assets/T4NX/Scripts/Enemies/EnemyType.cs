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
        /// </summary>
        BasicTank,

        /// <summary>
        /// Points: 200;
        /// Movement: 3 (Fast);
        /// Bullet: 2 (Normal);
        /// </summary>
        FastTank,

        /// <summary>
        /// Points: 300;
        /// Movement: 2 (Normal);
        /// Bullet: 3 (Fast);
        /// </summary>
        PowerTank,

        /// <summary>
        /// Points: 400;
        /// Movement: 2 (Normal);
        /// Bullet: 2 (Normal);
        /// </summary>
        ArmorTank,
        /// <summary>
        /// Just a counter of Enemies types
        /// </summary>
        TypeCount
    }
}
