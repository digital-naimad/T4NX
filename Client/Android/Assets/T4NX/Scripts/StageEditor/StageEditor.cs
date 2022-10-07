using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

namespace T4NX
{
    public class StageEditor : MonoSingleton<StageEditor>
    {
        public const PoolTag BlockButtonPoolTag = PoolTag.BlockButton;

        [SerializeField] private StageScriptableObject stageData;

        [SerializeField] private Transform terrainBlocksRoot;
        [SerializeField] private GridLayoutGroup terrainGrid;

        //[SerializeField] private BlockButton[,] blockButtonsGrid;
        [SerializeField] private TMP_InputField stageNameInputField;

        [SerializeField] private TMP_InputField stageSizeXInputField;
        [SerializeField] private TMP_InputField stageSizeYInputField;

        [SerializeField] private TMP_InputField enemyBasicTankInputField;
        [SerializeField] private TMP_InputField enemyFastTankInputField;
        [SerializeField] private TMP_InputField enemyPowerTankInputField;
        [SerializeField] private TMP_InputField enemyArmorTankInputField;


        [SerializeField] private string stagesDataPath = "Assets/T4NX/Data/Stages/";
        [SerializeField] private string filePrefix = "Stage_";
        private string fileExtension = ".asset";


        /*
        private int GridSizeX
        {
            get 
            { 
                return stageData.GridSizeX; 
            }
        }

        private int GridSizeY
        {
            get
            {
                return stageData.GridSizeY;
            }
        }
        */

        private void Awake()
        {
            /*
            if (stageData == null || terrainBlocksRoot == null)
            {
                Debug.Log("StageEditor >> stageScriptableObject or terrainBlocksRoot is null");
                return;
            }
            InitButtonsGrid(StageSettings.DefaultGridSize.x, StageSettings.DefaultGridSize.y);
            */
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        
        public void OnSizeXChanged()
        {
            Debug.Log("OnSizeXChanged() - TODO: implement changing state sizes");

           
        }


        public void OnSizeYChanged()
        {
            Debug.Log("OnSizeXChanged()");
        }

       

        /// <summary>
        /// For using by BlockButtons
        /// </summary>
        /// <param name="positionOnGrid"></param>
        /// <param name="terrainType"></param>
        public void ChangeBlock(Vector2Int positionOnGrid, TerrainType terrainType)
        {
            Debug.Log("StageEditor >> ChangeBlock " + positionOnGrid + " to " + terrainType);

            stageData.ChangeBlock(positionOnGrid.y, positionOnGrid.x, terrainType);
            stageData.ApplyToAsset();
        }

        public void UpdateBasicTankAmount()
        {
            stageData.SetEnemyTypeAmount(EnemyType.BasicTank, int.Parse(enemyBasicTankInputField.text));
        }

        public void UpdateFastTankAmount()
        {
            stageData.SetEnemyTypeAmount(EnemyType.FastTank, int.Parse(enemyFastTankInputField.text));
        }

        public void UpdatePowerTankAmount()
        {
            stageData.SetEnemyTypeAmount(EnemyType.PowerTank, int.Parse(enemyPowerTankInputField.text));
        }

        public void UpdateArmorTankAmount()
        {
            stageData.SetEnemyTypeAmount(EnemyType.ArmorTank, int.Parse(enemyArmorTankInputField.text));
        }

        /// <summary>
        /// On NEW STAGE button click
        /// </summary>
        public void OnNewStageButtonClick()
        {
            CreateNewStageData();
        }

        /// <summary>
        /// SAVE CHANGES button click
        /// </summary>
        public void OnButtonSaveChangesClick()
        {
            Debug.Log("OnButtonSaveChangesClick()");

           // stageData.SetGridSize();
        }


        /// <summary>
        /// 
        /// </summary>
        public void OnLoadStageClick()
        {
            LoadButtonsGridFromData();
        }

        /*
         
            // Constraint: Fixed column count
            //terrainGrid.constraintCount = stageData.GridSizeX;

            //blockButtonsGrid = new BlockButton[GridSizeY, GridSizeX];
        
                    //Debug.Log(">> iRow " + iRow + " iColumn " + iColumn);
                    //TerrainType blockType = stageData.GetTerrainType(iColumn, iRow);
          //blockButtonsGrid[iRow, iColumn] = block;

        
            //EditorUtility.SetDirty(newStage);
            //AssetDatabase.SaveAssets();
            // AssetDatabase.Refresh();

        */

        private void CreateNewStageData()
        {
            
            StageScriptableObject newStage = ScriptableObject.CreateInstance<StageScriptableObject>();
            newStage.InitTerrainGrid(StageSettings.DefaultGridSize.x, StageSettings.DefaultGridSize.y);

#if UNITY_EDITOR
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(stagesDataPath + filePrefix + stageNameInputField.text + fileExtension);
            AssetDatabase.CreateAsset(newStage, assetPathAndName);
#endif
            stageData = newStage;

            //AddSteelBorder();
            //AddBaseBrickBorder();
            SetupDefaultPositions();
            LoadButtonsGridFromData();
            
        }

        private void LoadButtonsGridFromData()
        {
            Debug.Log( name + " >> LoadButtonsGridFromData() X=" + stageData.GridSizeX + " Y=" + stageData.GridSizeY);
            stageSizeXInputField.text = "" + stageData.GridSizeX;
            stageSizeYInputField.text = "" + stageData.GridSizeY;

            // Constraint: Fixed column count
            terrainGrid.constraintCount = stageData.GridSizeX;

            for (int iRow = 0; iRow < stageData.GridSizeY; iRow++)
            {
                for (int iColumn = 0; iColumn < stageData.GridSizeX; iColumn++)
                {
                    BlockButton block = CreateBlockButton(stageData.GetTerrainType(iColumn, iRow)); // StageUtils.GetRandomTerrainType()
                    block.transform.SetParent(terrainBlocksRoot);
                    block.SetupPositionOnGrid(iColumn, iRow);
                }
            }
        }

        public void AddSteelBorder()
        {
            
            for (int iColumn = 0; iColumn < stageData.GridSizeX; iColumn++)
            {
                stageData.ChangeBlock(0, iColumn, TerrainType.Steel);
                stageData.ChangeBlock(1, iColumn, TerrainType.Steel);
                stageData.ChangeBlock(stageData.GridSizeY - 2, iColumn, TerrainType.Steel);
                stageData.ChangeBlock(stageData.GridSizeY - 1, iColumn, TerrainType.Steel);
            }

            for (int iRow = 2; iRow < stageData.GridSizeY - 2; iRow++)
            {
                stageData.ChangeBlock(iRow, 0, TerrainType.Steel);
                stageData.ChangeBlock(iRow, 1, TerrainType.Steel);
                stageData.ChangeBlock(iRow, stageData.GridSizeX - 4, TerrainType.Steel);
                stageData.ChangeBlock(iRow, stageData.GridSizeX - 3, TerrainType.Steel);
                stageData.ChangeBlock(iRow, stageData.GridSizeX - 2, TerrainType.Steel);
                stageData.ChangeBlock(iRow, stageData.GridSizeX - 1, TerrainType.Steel);
            }

            stageData.ApplyToAsset();
        }

        public void AddBaseBrickBorder() //int basePositionX
        {
            // left wall
            stageData.ChangeBlock(stageData.GridSizeY - 5, 13, TerrainType.Brick);
            stageData.ChangeBlock(stageData.GridSizeY - 4, 13, TerrainType.Brick);
            stageData.ChangeBlock(stageData.GridSizeY - 3, 13, TerrainType.Brick);

            // center ceil
            stageData.ChangeBlock(stageData.GridSizeY - 5, 14, TerrainType.Brick);
            stageData.ChangeBlock(stageData.GridSizeY - 5, 15, TerrainType.Brick);

            // right wall
            stageData.ChangeBlock(stageData.GridSizeY - 5, 16, TerrainType.Brick);
            stageData.ChangeBlock(stageData.GridSizeY - 4, 16, TerrainType.Brick);
            stageData.ChangeBlock(stageData.GridSizeY - 3, 16, TerrainType.Brick);

            stageData.ApplyToAsset();
        }

        /*
        private void InitButtonsGrid(int gridSizeX, int gridSizeY)
        {
            stageSizeXInputField.text = "" + gridSizeX;
            stageSizeYInputField.text = "" + gridSizeY;

            // Constraint: Fixed column count
            terrainGrid.constraintCount = gridSizeX;

            for (int iRow = 0; iRow < gridSizeY; iRow++)
            {
                for (int iColumn = 0; iColumn < gridSizeX; iColumn++)
                {
                    BlockButton block = CreateBlockButton(TerrainType.Empty); // StageUtils.GetRandomTerrainType()
                    block.transform.SetParent(terrainBlocksRoot);
                    block.SetupPositionOnGrid(iColumn, iRow);
                }
            }
        }
        */
        private BlockButton CreateBlockButton(TerrainType terrainBlockType)
        {
            GameObject gameObject = ObjectPooler.Instance.SpawnFromPool(BlockButtonPoolTag);
            BlockButton block = gameObject.GetComponentInChildren<BlockButton>();
            block.CurrentTerrainType = terrainBlockType;

           // Debug.Log(">> terrainBlockType " + terrainBlockType);
            return block;
        }

        private void SetupDefaultPositions()
        {
            stageData.AddPlayerSpawnPoint(new Vector2Int(80, 16));
            stageData.AddPlayerSpawnPoint(new Vector2Int(144, 16));

            stageData.AddEnemySpawnPoint(new Vector2Int(16, 208));
            stageData.AddEnemySpawnPoint(new Vector2Int(112, 208));
            stageData.AddEnemySpawnPoint(new Vector2Int(208, 208));

            stageData.AddPlayerBasePoint(new Vector2Int(112, 16));
        }


    }
}
