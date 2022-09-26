using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering.Universal;

namespace T4NX
{
    [CreateAssetMenu(fileName = "Stage_", menuName = "Stages/Stage", order = 2)]
    public class StageScriptableObject : ScriptableObject
    {
        //private static int StagesCounter = 0;

        //[SerializeField] private string _stageName = "Stage_" + (StageScriptableObject.StagesCounter++);

        [SerializeField] private int gridSizeX = StageSettings.DefaultGridSize.x;
        [SerializeField] private int gridSizeY = StageSettings.DefaultGridSize.y;

        //[SerializeField] private string[] terrainPreview;
        //[SerializeField] private char[,] terrainGrid = new char[StageSettings.DefaultGridSize.y, StageSettings.DefaultGridSize.x];
       // [SerializeField] private byte[,] terrainGrid = new byte[StageSettings.DefaultGridSize.y, StageSettings.DefaultGridSize.x];
        [SerializeField] private byte[] terrainData = new byte[StageSettings.DefaultGridSize.y * StageSettings.DefaultGridSize.x];

        // [SerializeField] private List<string> _gridList = new List<string>();
        //[SerializeField] private List<List<char>> _terrainGrid = new List<List<char>>();
        // [SerializeField] private char[,] _terrainGrid = { { 'E' } };

        [SerializeField] private List<Vector2Int> _playerSpawnPoints = new List<Vector2Int>();
        [SerializeField] private List<Vector2Int> _enemySpawnPoints = new List<Vector2Int>();
        [SerializeField] private List<Vector2Int> _playerBasePoints = new List<Vector2Int>();

        //public string StageName
        //{
            //get { return _stageName; }
        //}

        public int GridSizeX
        {
            get 
            {
                //return _terrainGrid.GetLength(1);//_gridList[0].Length; 

                return gridSizeX;// terrainGrid.GetLength(1);// terrainPreview[0].Length;
            }

        }

        public int GridSizeY
        {
            get
            {
                //return _terrainGrid.GetLength(0);//_gridList.Count;
                return gridSizeY; // terrainGrid.GetLength(0); // terrainPreview.Length;
            }
        }

        public int PlayerSpawnPointsCount
        {
            get
            { 
                return _playerSpawnPoints.Count; 
            }  
        }

        public int EnemySpawnPointsCount
        {
            get
            {
                return _enemySpawnPoints.Count;
            }
        }
         
        public int PlayerBasePointsCount
        {
            get
            {
                return _playerBasePoints.Count;
            }
        }

        public StageScriptableObject()
        {
            //Debug.Log(" StageScriptableObject >> CALLS CONSTRUCTOR");
            /*
            terrainGrid = new byte[StageSettings.DefaultGridSize.y, StageSettings.DefaultGridSize.x];
            for (int iRow = 0; iRow < GridSizeY; iRow++)
            {
                //terrainPreview[iRow] = "";

                for (int iColumn = 0; iColumn < GridSizeX; iColumn++)
                {

                    //_terrainGrid[iRow, iColumn] = newType;
                    //terrainPreview[iRow] += newType;

                    terrainGrid[iRow, iColumn] = (byte)TerrainType.Empty;
                }
            }
            */
        }

        private void Awake()
        {
            //Debug.Log(">> StageScriptableObject Awake() call");
            //InitTerrainGrid();// StageSettings.DefaultGridSize.x, StageSettings.DefaultGridSize.y);// GridSizeX, GridSizeY);
        }

        /// <summary>
        /// To use by StageController
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public TerrainType GetTerrainType(int x, int y)
        {
            //Debug.Log(name + " >> GetTerrainType(x, y) " + GetTerrainByte(x, y));

            //return (TerrainType)(GetTerrainByte(x, y));

            return (TerrainType)(GetTerrainByte(x, y));
            //char letter = GetTerrainByte(x, y);
            //return StageUtils.ConvertCharToTerrainType(letter);
            /*
            string letterString = "" + letter;
            switch (letterString)
            {
                case nameof(BlockShortcut.B):
                case nameof(BlockShortcut.U):
                case nameof(BlockShortcut.I):
                case nameof(BlockShortcut.S):
                case nameof(BlockShortcut.W):
                case nameof(BlockShortcut.D):
                case nameof(BlockShortcut.E):
                    return StageUtils.ConvertCharToTerrainType(letter);
                default:
                    return TerrainType.Empty;
            }
            */
        }

        public byte GetTerrainByte(int x, int y)
        {
            int index = y * gridSizeX + x;
            return terrainData[index]; //terrainGrid[y, x];
        }
            

        public void SetGridSize(int sizeX, int sizeY)
        {
            gridSizeX = sizeX;
            gridSizeY = sizeY;
        }
        

        /// <summary>
        /// Initiates grid (list and strings) with empty terrain blocks
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        public void InitTerrainGrid(int sizeX, int sizeY)
        {
            //_terrainGrid = new char[sizeY, sizeX];
            //terrainPreview = new string[sizeY];
            SetGridSize(sizeX, sizeY);
            //terrainGrid = new byte[GridSizeY, GridSizeX];


            //byte newType = (byte)TerrainType.Empty;//StageUtils.ConvertTerrainTypeToChar(TerrainType.Empty);
            //Debug.Log(name + " >> InitTerrainGrid() newType=" + newType);


            for (int iRow = 0; iRow < GridSizeY; iRow++)
            {
                //terrainPreview[iRow] = "";

                for (int iColumn = 0; iColumn < GridSizeX; iColumn++)
                {

                    //_terrainGrid[iRow, iColumn] = newType;
                    //terrainPreview[iRow] += newType;

                    //terrainGrid[iRow, iColumn] = newType;

                    terrainData[iRow * GridSizeX + iColumn] = (byte)TerrainType.Empty;
                }
            }

            ApplyToAsset();
        }

        /// <summary>
        /// Adds another block to the row given by "y"
        /// </summary>
        /// <param name="terrainType"></param>
        /// <param name="y"></param>
        /*
        public void AddNextTerrainType(TerrainType terrainType, int y)
        {
            switch (terrainType)
            {
                case TerrainType.Brick:
                case TerrainType.Bush:
                case TerrainType.Ice:
                case TerrainType.Steel:
                case TerrainType.Water:
                case TerrainType.DeepWater:
                case TerrainType.Empty:
                    _gridList[y] += StageUtils.ConvertTerrainTypeToChar(terrainType);
                    break;
                default:
                    _gridList[y] += 'E';
                    break;
            }
        }
        */

        /// <summary>
        /// Inverts Y grid position then calls ChangeBlock(x, y, terrainType)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="terrainType"></param>
        public void ModifyBlock(int x, int y, TerrainType terrainType)
        {
            ChangeBlock(GridSizeY - y - 1, x, terrainType); 
        }

        /// <summary>
        /// Changes terrainType of block at position (x = column, y = row)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="terrainType"></param>
        public void ChangeBlock(int row, int column, TerrainType terrainType)
        {
            //Debug.Log(name + " >> ChangeBlock(row=" + row + ", column=" + column + ", terrainType=" + terrainType + ")");

            //char newType = StageUtils.ConvertTerrainTypeToChar(terrainType);
           // byte newType = (byte)terrainType;
            //_terrainGrid[row, column] = newType;

            /*
            char[] charPreview = terrainPreview[row].ToCharArray();
            charPreview[column] = newType;
            terrainPreview[row] = new string(charPreview);
            */

           // 
            //terrainGrid[row, column] = newType;
            terrainData[row * GridSizeX + column] = (byte)terrainType;

            //Debug.Log(name + " >> ChangeBlock() terrainType=" + terrainType + " newType=" + (byte)terrainType);
            ApplyToAsset();
        }

        /*

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public byte GetTerrainByte(int x, int y)
        {
            //Debug.Log(">> x " + x + " y " + y);

            //string row = _gridList[y % _gridList.Count];
            // return row[x % row.Length];

            //return _terrainGrid[y % GridSizeY, x % GridSizeX];
            return terrainGrid[y, x]; //terrainPreview[y][x];
        }
        */
        /// <summary>
        /// Adds spawn point to list to store in scriptable object
        /// </summary>
        /// <param name="spawnPoint"></param>
        public void AddPlayerSpawnPoint(Vector2Int spawnPoint)
        {
            if (_playerSpawnPoints == null)
            {
                _playerSpawnPoints = new List<Vector2Int>();
            }
            _playerSpawnPoints.Add(spawnPoint);

            //Debug.Log("StageScriptableObject >> AddSpawnPoint spawnPoints.Count " + _spawnPoints.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector2Int GetPlayerSpawnPoint(int index)
        {
            return _playerSpawnPoints[index % _playerSpawnPoints.Count];
        }

        /// <summary>
        /// Enemy Spawn Point
        /// </summary>
        /// <param name="spawnPoint"></param>
        public void AddEnemySpawnPoint(Vector2Int spawnPoint)
        {
            if (_enemySpawnPoints == null)
            {
                _enemySpawnPoints = new List<Vector2Int>();
            }
            _enemySpawnPoints.Add(spawnPoint);
        }

        
        public Vector2Int GetEnemySpawnPoint(int index)
        {
            return _enemySpawnPoints[index % _enemySpawnPoints.Count];
        }

        /// <summary>
        /// Player Base position
        /// </summary>
        /// <param name="spawnPoint"></param>
        public void AddPlayerBasePoint(Vector2Int spawnPoint)
        {
            if (_playerBasePoints == null)
            {
                _playerBasePoints = new List<Vector2Int>();
            }
            _playerBasePoints.Add(spawnPoint);
        }

        public Vector2Int GetPlayerBasePoint(int index)
        {
            return _playerBasePoints[index % _playerBasePoints.Count];
        }

        public void ApplyToAsset()
        {
#if UNITY_EDITOR


            EditorUtility.SetDirty(this);
    
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
#endif
        }
    }
}
