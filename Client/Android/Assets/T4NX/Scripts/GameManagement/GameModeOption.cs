using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    [System.Serializable]
    public struct GameModeOption
    {
        public GameType gameMode;
        public GameModeController controller;
    }
}