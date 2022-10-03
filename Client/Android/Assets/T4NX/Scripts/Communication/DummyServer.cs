using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerIOClient;

namespace T4NX
{
    public class DummyServer : MonoSingleton<DummyServer>
    {
        private class DummyPlayer
        {
            public string name;
            public int no = 0; // number
            public int positionX;
            public int positionY;

            public int colorA = (int)ColorName.blue0;
            public int colorB = (int)ColorName.yellow0;
            public int colorC = (int)ColorName.purple0;
        }

        private List<DummyPlayer> players = new List<DummyPlayer>();

        // Stage data
        private int gridSizeX;
        private int gridSizeY;
        private byte[] terrainData;

        private List<Vector2Int> playerSpawnPoints = new List<Vector2Int>();
        //private List<int> playerSpawnPointsX = new List<int>();
        //private List<int> playerSpawnPointsY = new List<int>();

        private List<Vector2Int> enemySpawnPoints = new List<Vector2Int>();
        //private List<int> enemySpawnPointsX = new List<int>();
        //private List<int> enemySpawnPointsY = new List<int>();

        private List<Vector2Int> playerBasePoints = new List<Vector2Int>();

        private List<int> enemyTypesAmount = new List<int>();

        void Start()
        {
            SendMessagesSequence();
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        /// <summary>
        /// Responses to messages from GameServer
        /// </summary>
        /// <param name="message"></param>
        public void SendGameMessage(Message message)
        {
            switch (message.Type)
            {
                case nameof(MessageType.S): // Sends default stage
                    gridSizeX = message.GetInt(0);
                    gridSizeY = message.GetInt(1);
                    terrainData = message.GetByteArray(2);

                    uint index = 3;

                    // Number of PLAYER SPAWN points
                    int numberOfPlayerSpawnPoints = message.GetInt(index);
                    index++;

                    playerSpawnPoints.Clear();
                    for (uint iPoint = 0; iPoint < numberOfPlayerSpawnPoints; iPoint++, index += 2)
                    {
                        playerSpawnPoints.Add(new Vector2Int(message.GetInt(index + iPoint), message.GetInt(index + iPoint + 1)));
                    }

                    // Number of ENEMY SPAWN points
                    int numberOfEnemySpawnPoints = message.GetInt(index);
                    index++;

                    enemySpawnPoints.Clear();
                    for (uint iPoint = 0; iPoint < numberOfEnemySpawnPoints; iPoint++, index += 2)
                    {
                        enemySpawnPoints.Add(new Vector2Int(message.GetInt(index + iPoint), message.GetInt(index + iPoint + 1)));
                    }

                    // Number of Player Base Points
                    int numberOfPlayerBasePoints = message.GetInt(index);
                    index++;

                    playerBasePoints.Clear();
                    for (uint iPoint = 0; iPoint < numberOfPlayerBasePoints; iPoint++, index += 2)
                    {
                        playerBasePoints.Add(new Vector2Int(message.GetInt(index + iPoint), message.GetInt(index + iPoint + 1)));
                    }

                    /*
                    int numberOfPlayerSpawnPoints = message.GetInt(3);

                    playerSpawnPoints.Clear();
                    for (uint i = 4; i <= 4 + numberOfPlayerSpawnPoints; i+=2)
                    {
                        playerSpawnPoints.Add(new Vector2Int(message.GetInt(i), message.GetInt(i + 1)));
                    }
                    */

                    SendStageMessage();
                    break;
            }
        }

        private void SendMessagesSequence()
        {
            //Invoke(nameof(SendSpawnPlayerTankMessage), 1.0f);
        }

        /// <summary>
        /// Prepares and sends terrainData to the client
        /// </summary>
        private void SendStageMessage()
        {
            Message messageToSend = Message.Create(nameof(MessageType.S)); // message type

            messageToSend.Add(gridSizeX); // 0
            messageToSend.Add(gridSizeY); // 1
            messageToSend.Add(terrainData); // 2

            // Player Spawn Points
            messageToSend.Add(playerSpawnPoints.Count); // 3
            for (int i = 0; i < playerSpawnPoints.Count; i++)
            {
                messageToSend.Add(playerSpawnPoints[i].x); // 4+i
                messageToSend.Add(playerSpawnPoints[i].y); // 4+i+1
            }

            // Enemy Spawn Points 
            messageToSend.Add(enemySpawnPoints.Count);
            for (int i = 0; i < enemySpawnPoints.Count; i++)
            {
                messageToSend.Add(enemySpawnPoints[i].x); // n+4+i
                messageToSend.Add(enemySpawnPoints[i].y); // n+4+i+1
            }

            // Player Base Points
            messageToSend.Add(playerBasePoints.Count);
            for (int i = 0; i < playerBasePoints.Count; i++)
            {
                messageToSend.Add(playerBasePoints[i].x); // n+m+4+i
                messageToSend.Add(playerBasePoints[i].y); // n+m+4+i+1
            }

            // Enemy type amounts
            messageToSend.Add(enemyTypesAmount.Count);
            for (int i = 0; i < enemyTypesAmount.Count; i++)
            {
                messageToSend.Add(enemyTypesAmount[i]);
            }

            // Debug.Log(">> DummyServer >> spawnPointsX[i] " + spawnPointsX[i]);
            // Debug.Log(">> DummyServer >> spawnPointsY[i] " + spawnPointsY[i]);


            GameServer.Instance.HandleSingleMessage(messageToSend);
        }

        /// <summary>
        /// Prepares and sends SpawnTank message to the client
        /// </summary>
        private void SendSpawnEnemyTankMessage()
        {
            //Debug.Log("DummyServer >> SendSpawnTankMessage count: " + spawnPointsX.Count);

            Vector2Int randomSpawnPosition = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)];
            //int randomPositionX = playerSpawnPointsX[Random.Range(0, playerSpawnPointsX.Count)];
            //int randomPositionY = playerSpawnPointsY[Random.Range(0, playerSpawnPointsY.Count)];

            Message messageToSend = Message.Create(nameof(MessageType.SET));
            messageToSend.Add(randomSpawnPosition.x);
            messageToSend.Add(randomSpawnPosition.y);

            GameServer.Instance.HandleSingleMessage(messageToSend);
        }

        /// <summary>
        /// Prepares and sends SpawnPlayerTank message to the client
        /// </summary>
        private void SendSpawnPlayerTankMessage()
        {
            Vector2Int randomSpawnPosition = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Count)];

            // int randomPositionX = playerSpawnPointsX[Random.Range(0, playerSpawnPointsX.Count)];
            // int randomPositionY = playerSpawnPointsY[Random.Range(0, playerSpawnPointsY.Count)];

            DummyPlayer tank = CreateTank(randomSpawnPosition);//, randomPositionY);

            Message messageToSend = Message.Create(nameof(MessageType.SPT));

            messageToSend.Add(tank.name); // 0 string

            messageToSend.Add(tank.positionX); // 1 int
            messageToSend.Add(tank.positionY); // 2 int

            messageToSend.Add(tank.colorA); // 3 int
            messageToSend.Add(tank.colorB); // 4 int
            messageToSend.Add(tank.colorC); // 5 int

            GameServer.Instance.HandleSingleMessage(messageToSend);
        }

        private DummyPlayer CreateTank(Vector2Int spawnPosition) //int positionX, int positionY)
        {
            DummyPlayer dummyPlayer = new DummyPlayer();
            dummyPlayer.name = "Player 1";
            dummyPlayer.positionX = spawnPosition.x;
            dummyPlayer.positionY = spawnPosition.y;
            players.Add(dummyPlayer);
            return dummyPlayer;
        }


    }

}
