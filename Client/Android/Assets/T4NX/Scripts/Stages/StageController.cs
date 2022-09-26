using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerIOClient;

namespace T4NX
{
    public class StageController : MonoSingleton<StageController>
    {
        public const PoolTag PlayerBasePoolTag = PoolTag.PlayerBase; // TODO: move this to stage factory

        [SerializeField] private TerrainBlock[,] terrainBlocksGrid;

        [SerializeField] private Transform playfieldRoot;
        [SerializeField] private TanksManager tanksManager;

        [SerializeField] private StageScriptableObject _defaultStage;
        [SerializeField] private StageScriptableObject _currentStage;

        private void Awake()
        {
            BlockPattern.FillPatternsDictionary();    
        }

        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SpawnTank()
        {

        }

        /// <summary>
        /// Fullfills stage terrain with blocks grid defined in CurrentStage. 
        /// Warning: Before call make sure that CurrentStage field is not null.
        /// </summary>
        public void FullfillStage()
        {
            //Debug.Log("StageController >> FullfillStage()");
            if (_currentStage == null)
                return;

            terrainBlocksGrid = new TerrainBlock[_currentStage.GridSizeY, _currentStage.GridSizeX];

            for (int iRow = 0; iRow < _currentStage.GridSizeY; iRow++)
            {
                for (int iColumn = 0; iColumn < _currentStage.GridSizeX; iColumn++)
                {
                    //Debug.Log(">> iRow " + iRow + " iColumn " + iColumn);
                    TerrainType blockType = _currentStage.GetTerrainType(iColumn, iRow);

                    //Debug.Log(name + " >>  FullfillStage() blockType " + blockType);

                    TerrainBlock block = BlockFactory.Instance.CreateTerrainBlock(blockType);
                    block.transform.SetParent(playfieldRoot);
                    block.transform.position = StageUtils.ConvertVector2IntTo3(
                    StageSettings.GridOffsetSize.x + iColumn * StageSettings.SubblockSize.x,
                    StageSettings.GridOffsetSize.y - iRow * StageSettings.SubblockSize.y);

                    //Debug.Log(">>> position " + block.transform.position);

                    terrainBlocksGrid[_currentStage.GridSizeY - iRow - 1, iColumn] = block;
                }
            }

            // Eagle - Player Base
            for (int iBase = 0; iBase < _currentStage.PlayerBasePointsCount; iBase++)
            {
                GameObject baseObject = ObjectPooler.Instance.SpawnFromPool(PlayerBasePoolTag);
                baseObject.transform.SetParent(playfieldRoot);
                baseObject.transform.position = StageUtils.ConvertVector2IntTo3(_currentStage.GetPlayerBasePoint(iBase));

                //Debug.Log(">>> player base position " + baseObject.transform.position);

                TerrainBlock blockAtPlayerBase = GetTerrainBlockAtPosition(baseObject.transform.position);
                blockAtPlayerBase.TerrainBlockType = TerrainType.Empty;
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionOnGrid"></param>
        /// <param name="terrainType"></param>
       // public void UpdateTerrainType(Vector2Int positionOnGrid, TerrainType terrainType)
        public void UpdateTerrainType(int x, int y, TerrainType terrainType)
        {
            TerrainBlock blockAtPosition = GetTerrainBlockAtPosition(x, y);
            blockAtPosition.TerrainBlockType = terrainType;
            //blockAtPosition.ApplyType();
            //blockAtPosition.gameObject.SetActive(false);
        }

        #region Getting data from Default Stage
        public int GetTerrainDataGridSizeX()
        {
            return _defaultStage.GridSizeX;
        }

        public int GetTerrainDataGridSizeY()
        {
            return _defaultStage.GridSizeY;
        }

        public Byte[] GetTerrainDataForUpload()
        {

            Byte[] stageData = new Byte[_defaultStage.GridSizeY * _defaultStage.GridSizeX];
            for (int iRow = 0; iRow < _defaultStage.GridSizeY; iRow++)
            {
                for (int iColumn = 0; iColumn < _defaultStage.GridSizeX; iColumn++)
                {
                    //Debug.Log(">> TerrainType: " + (Byte)(_stage.GetTerrainType(iColumn, iRow)));

                    stageData[iRow * _defaultStage.GridSizeX + iColumn] = _defaultStage.GetTerrainByte(iColumn, iRow);
                }
            }
           
            return stageData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> number of a spawn points on default stage</returns>
        public int GetPlayerSpawnPointsCount()
        {
            return _defaultStage.PlayerSpawnPointsCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> number of a spawn points on default stage</returns>
        public int GetEnemySpawnPointsCount()
        {
            return _defaultStage.EnemySpawnPointsCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> number of a player base points on default stage</returns>
        public int GetPlayerBasePointsCount()
        {
            return _defaultStage.PlayerBasePointsCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Vector2Int: spawn point from default stage</returns>
        public Vector2Int GetPlayerSpawnPoint(int index)
        {
            return _defaultStage.GetPlayerSpawnPoint(index);
        }

        public Vector2Int GetEnemySpawnPoint(int index)
        {
            return _defaultStage.GetEnemySpawnPoint(index);
        }

        public Vector2Int GetPlayerBasePoint(int index)
        {
            return _defaultStage.GetPlayerBasePoint(index);
        }
        #endregion

        #region Setting up Current Stage
        /// <summary>
        /// Call before FullfillStage()
        /// </summary>
        /// <param name="currentStage"></param>
        public void SetCurrentStage(StageScriptableObject currentStage)
        {
            _currentStage = currentStage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridSizeX"></param>
        /// <param name="gridSizeY"></param>
        /// <param name="terrainData"></param>
        public void LoadTerrainData(int gridSizeX, int gridSizeY, byte[] terrainData)
        {
            StageScriptableObject newStage = ScriptableObject.CreateInstance<StageScriptableObject>();

            //newStage.SetGridSize(gridSizeX, gridSizeY);
            newStage.InitTerrainGrid(gridSizeX, gridSizeY);

            for (int iRow = 0; iRow < gridSizeY; iRow++)
            {
                for (int iColumn = 0; iColumn < gridSizeX; iColumn++)
                {
                    TerrainType terrainType = (TerrainType)terrainData[iRow * gridSizeX + iColumn];
                    //newStage.AddNextTerrainType(terrainType, iRow);
                    newStage.ChangeBlock(iRow, iColumn, terrainType);
                }
            }
            _currentStage = newStage;
        }

        /// <summary>
        /// Adds PLAYER SPAWN POINTS to the current stage
        /// </summary>
        public void SetupPlayerSpawnPositions(Vector2Int[] spawnPoints)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                //Debug.Log("StageController >> Adds spawn point to current stage " + spawnPoints[i]);

                _currentStage.AddPlayerSpawnPoint(spawnPoints[i]);
            }
           
        }

        /// <summary>
        /// Adds ENEMY SPAWN POINTS to the current stage
        /// </summary>
        public void SetupEnemySpawnPositions(Vector2Int[] spawnPoints)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                //Debug.Log("StageController >> Adds spawn point to current stage " + spawnPoints[i]);

                _currentStage.AddPlayerSpawnPoint(spawnPoints[i]);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePoints"></param>
        public void SetupPlayerBasePositions(Vector2Int[] basePoints)
        {
            for (int i = 0; i < basePoints.Length; i++)
            {
                _currentStage.AddPlayerBasePoint(basePoints[i]);
            }

        }
        #endregion

        #region Internal utils
        private TerrainBlock GetTerrainBlockAtPosition(GameObject gameObject)
        {
            return GetTerrainBlockAtPosition(gameObject.transform.position);
        }


        private TerrainBlock GetTerrainBlockAtPosition(Vector3 position)
        {
            int x = (int)position.x / StageSettings.SubblockSize.x; //Mathf.FloorToInt(position.x / StageSettings.SubblockSize.x);
            int y = (int)position.y / StageSettings.SubblockSize.y; //Mathf.FloorToInt(position.y / StageSettings.SubblockSize.y);
            // Debug.Log(">>> x " + x + " y " + y);
            return terrainBlocksGrid[y, x];
        }

        private TerrainBlock GetTerrainBlockAtPosition(int x, int y)
        {
            //Debug.Log(name + " >>> GetTerrainBlockAtPosition x " + x + " y " + y);
            //Debug.Log(" >>> " + terrainBlocksGrid[y, x]);
            return terrainBlocksGrid[y, x];
        }

        private TerrainBlock GetTerrainBlockAtPosition(Vector2Int position)
        {
            int x = Mathf.FloorToInt(position.x / StageSettings.SubblockSize.x);
            int y = Mathf.FloorToInt(position.y / StageSettings.SubblockSize.y);
            Debug.Log(name + " >> x " + x + " y " + y);
            return terrainBlocksGrid[y, x];
        }
        #endregion
    }
}
