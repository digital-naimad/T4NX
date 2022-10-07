using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class TanksManager : MonoSingleton<TanksManager>
    {
        public static PoolTag TankPrefabTag = PoolTag.PlayerTank;

        [SerializeField] private List<TankController> tanks;
        [SerializeField] private Transform worldRoot;

        private void Awake()
        {
            tanks = new List<TankController>();
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //public void SpawnPlayerTank(string tankerName, int positionX, int positionY, ColorName colorA, ColorName colorB, ColorName colorC)
        /// <summary>
        /// Spawns player's tank on the stage
        /// </summary>
        /// <param name="playerID"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="colorA"></param>
        /// <param name="colorB"></param>
        /// <param name="colorC"></param>
        public void SpawnPlayerTank(int playerID, int positionX, int positionY, ColorName colorA, ColorName colorB, ColorName colorC)
        {
            TankController newTank = ObjectPooler.Instance.SpawnFromPool(TankPrefabTag).GetComponent<TankController>();
            newTank.InitWithData(playerID, colorA, colorB, colorC);

            tanks.Add(newTank);

            newTank.transform.SetParent(worldRoot);
            newTank.transform.position = new Vector3(positionX, positionY);
        }
    }
}
