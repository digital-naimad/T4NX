using System;
using UnityEngine;

namespace T4NX
{
    [Serializable]
    public struct Pool
    {
        public PoolTag tag;
        public GameObject prefab;
        public short poolSize;
    }
}