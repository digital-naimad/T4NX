using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public enum PowerUpType 
    {
        /// <summary>
        /// * Destroys every enemy currently on the screen.
        /// * No credit given for destroying the tanks wiped out by this powerup during the end-stage bonus points tally.
        /// </summary>
        Grenade,

        /// <summary>
        /// * Gives a temporary force field that shields from enemy shots, like the one at the beginning of every stage.
        /// </summary>
        Helmet,

        /// <summary>
        /// * Turns the brick walls around the fortress to stone, which gives temporary invulnerability to the walls, preventing enemies from destroying it.
        /// * Repairs all the damage previously done to the wall.
        /// </summary>
        Shovel,

        /// <summary>
        /// * Increases your offensive power by one tier (tiers are: default, second, third, and fourth). Power level only resets to default when you die.
        /// * First star (second tier): fired bullets are as fast as Power Tanks' bullets.
        /// * Second star (third tier): two bullets can be fired on the screen at a time.
        /// * Third star (fourth tier): fired bullets can destroy steel walls and are twice as effective against brick walls.
        /// </summary>
        Star,

        /// <summary>
        /// * Gives an extra life.
        /// * The only other way to earn an extra life is to score 20,000 points.
        /// </summary>
        Tank,

        /// <summary>
        /// * The timer power-up temporarily freezes time, stopping all enemy tanks' movement.
        /// Tip: enables the ability to harmlessly approach every tank and destroy them.
        /// </summary>
        Timer,

        /// <summary>
        /// Just a counter of existing Power Up types
        /// </summary>
        TypeCount
    }
}
