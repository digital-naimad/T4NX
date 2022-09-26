using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public enum MessageType 
    {
        // client => server

        

        // server => client

        /// <summary>
        /// User lefts room
        /// </summary>
        UserLeft,
        /// <summary>
        /// User joins to room
        /// </summary>
        UserJoined,
        /// <summary>
        /// [ S ]pawn [ E ]nemy [ T ]ank
        /// </summary>
        SET,
        /// <summary>
        /// [ S ]pawn [ P ]layer [ T ]ank
        /// </summary>
        SPT,

        //  both ways  <=>

        /// <summary>
        /// [ T ]errain
        /// </summary>
        T,
        Chat,
    }
}
