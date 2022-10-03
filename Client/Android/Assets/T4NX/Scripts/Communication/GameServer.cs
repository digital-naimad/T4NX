using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using PlayerIOClient;

namespace T4NX
{
    public class GameServer : MonoSingleton<GameServer>
    {
        [SerializeField] private bool isLocalServerUsed = false;
        [SerializeField] private bool isSimulationMode = true;

        private Connection connection = null;
        private Client client = null;

        private List<Message> messagesList = new List<Message>(); //  Messsage queue implementation

        // Start is called before the first frame update
        void Start()
        {
            //UploadTerrain(); // TODO: move it from here
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            HandleMessages();
        }

        
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void HandleSingleMessage(Message message)
        {
            //Debug.Log(Convert.ToString((int)MessageType.SpawnTank));

            switch (message.Type)
            {
                case nameof(MessageType.S):
                    LoadStageData(message);
                    break;
                case nameof(MessageType.SPT):
                    SpawnPlayerTank(message);
                    break;
                case nameof(MessageType.SET):
                    SpawnEnemyTank(message);
                    break;
                    // team membership (in another message)
            }
        }

        /// <summary>
        /// Universal PlayerIO message sender
        /// </summary>
        /// <param name="message"></param>
        public void SendGameMessage(Message message)
        {
            if (isSimulationMode)
            {
                DummyServer.Instance.SendGameMessage(message);
            }
        }

        /// <summary>
        /// Creates and sends message including TerrainData byte[] from StageController
        /// </summary>
        public void UploadTerrain()
        {
            //Debug.Log("GameServer >> Upload Terrain");

            Message message = Message.Create(nameof(MessageType.S)); // Message type

            message.Add(StageController.Instance.GetTerrainDataGridSizeX()); // 0
            message.Add(StageController.Instance.GetTerrainDataGridSizeY()); // 1
            message.Add(StageController.Instance.GetTerrainDataForUpload()); // 2

            // Player Spawn Points
            int numberOfPlayerSpawnPoints = StageController.Instance.GetPlayerSpawnPointsCount();
            message.Add(numberOfPlayerSpawnPoints); //3

            //Debug.Log("GameServer >> numberOfPlayerSpawnPoints " + numberOfPlayerSpawnPoints);
            
            for (int i = 0; i < numberOfPlayerSpawnPoints; i++)
            {
                message.Add(StageController.Instance.GetPlayerSpawnPoint(i).x); 
                message.Add(StageController.Instance.GetPlayerSpawnPoint(i).y); 

                //Debug.Log("GameServer >> StageController.Instance.GetPlayerSpawnPoint(i)" + StageController.Instance.GetPlayerSpawnPoint(i));
            }

            //Debug.Log("GameServer >> message count " + (message.Count));

            // Enemy Spawn Points 
            int numberOfEnemySpawnPoints = StageController.Instance.GetEnemySpawnPointsCount();
            message.Add(numberOfEnemySpawnPoints);

            //Debug.Log("GameServer >> numberOfEnemySpawnPoints " + numberOfEnemySpawnPoints);

            for (int i = 0; i < numberOfEnemySpawnPoints; i++)
            {
                message.Add(StageController.Instance.GetEnemySpawnPoint(i).x); 
                message.Add(StageController.Instance.GetEnemySpawnPoint(i).y); 

               // Debug.Log("GameServer >> StageController.Instance.GetEnemySpawnPoint(i)" + StageController.Instance.GetEnemySpawnPoint(i));
            }

            //Debug.Log("GameServer >> message count " + (message.Count));

            // Player Base Points
            int numberOfPlayerBasePoints = StageController.Instance.GetPlayerBasePointsCount();
            message.Add(numberOfPlayerBasePoints); //3

            //Debug.Log("GameServer >> numberOfPlayerBasePoints " + numberOfPlayerBasePoints);

            for (int i = 0; i < numberOfPlayerBasePoints; i++)
            {
                message.Add(StageController.Instance.GetPlayerBasePoint(i).x); 
                message.Add(StageController.Instance.GetPlayerBasePoint(i).y);

                //Debug.Log("GameServer >> StageController.Instance.GetPlayerBasePoint(i)" + StageController.Instance.GetPlayerBasePoint(i));
            }

            //Debug.Log("GameServer >> message.count " + (message.Count));

            SendGameMessage(message);
        }

        private void HandleMessages()
        {

            foreach (Message message in messagesList)
            {
                HandleSingleMessage(message);
            }
        }

        private void LoadStageData(Message message)
        {
            // Debug.Log(name + " >> LoadStageData");

            // gridSizeX, gridSizeY, terrainData
            StageController.Instance.LoadTerrainData(message.GetInt(0), message.GetInt(1), message.GetByteArray(2)); // 0, 1, 2

            uint index = 3;

            // Number of PLAYER SPAWN points
            uint numberOfPlayerSpawnPoints = (uint)message.GetInt(index); // 3
            index++;

            // Player spawn points
            Vector2Int[] playerSpawnPoints = new Vector2Int[numberOfPlayerSpawnPoints];
            for (uint iPoint = 0; iPoint < numberOfPlayerSpawnPoints; iPoint++, index += 2)
            {
                playerSpawnPoints[iPoint] = new Vector2Int(message.GetInt(index + iPoint), message.GetInt(index + iPoint + 1)); // 4+i, 4+i+1
            }
            StageController.Instance.SetupPlayerSpawnPositions(playerSpawnPoints);
            

            // Number of ENEMY SPAWN points
            uint numberOfEnemySpawnPoints = (uint)message.GetInt(index);
            index++;

            // Enemy spawn pointsR
            Vector2Int[] enemySpawnPoints = new Vector2Int[numberOfEnemySpawnPoints];
            for (uint iPoint = 0; iPoint < numberOfEnemySpawnPoints; iPoint++, index += 2)
            {
                enemySpawnPoints[iPoint] = new Vector2Int(message.GetInt(index + iPoint), message.GetInt(index + iPoint + 1));
            }
            StageController.Instance.SetupEnemySpawnPositions(enemySpawnPoints);
            

            // Number of Player Base Points
            uint numberOfPlayerBasePoints = (uint)message.GetInt(index);
            index++;

            // Player BASE Points
            Vector2Int[] playerBasePoints = new Vector2Int[numberOfPlayerBasePoints];
            for (uint iPoint = 0; iPoint < numberOfPlayerBasePoints; iPoint++, index += 2)
            {
                playerBasePoints[iPoint] = new Vector2Int(message.GetInt(index + iPoint), message.GetInt(index + iPoint + 1));
            }
            StageController.Instance.SetupPlayerBasePositions(playerBasePoints);

            StageController.Instance.FullfillStage();
        }

        private void SpawnEnemyTank(Message message)
        {
            /*
            string tankerID = message.GetString(0);
            Vector2Int positionToSpawn = new Vector2Int(message.GetInt(1), message.GetInt(2));
            ColorName colorA = (ColorName)message.GetInt(3);
            ColorName colorB = (ColorName)message.GetInt(4);
            ColorName colorC = (ColorName)message.GetInt(5);

            TanksManager.Instance.SpawnPlayerTank(tankerID, positionToSpawn.x, positionToSpawn.y, colorA, colorB, colorC);
            */
        }

        private void SpawnPlayerTank(Message message)
        {
            string tankerName = message.GetString(0);

            Vector2Int positionToSpawn = new Vector2Int(message.GetInt(1), message.GetInt(2));

            ColorName colorA = (ColorName)message.GetInt(3);
            ColorName colorB = (ColorName)message.GetInt(4);
            ColorName colorC = (ColorName)message.GetInt(5);

            TanksManager.Instance.SpawnPlayerTank(tankerName, positionToSpawn.x, positionToSpawn.y, colorA, colorB, colorC);
        }
    }
}
