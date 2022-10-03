using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class ConstructionController : GameplayModeController, IGamepadEventsListener
    {
        [SerializeField] private StageScriptableObject _constructionStage;

        [SerializeField] private TankCursor _cursor;
        [SerializeField] private Vector2Int _cursorPosition = Vector2Int.one * 16;
        [SerializeField] private Vector2Int _cursorInitialPosition = new Vector2Int(16, 208);

        [SerializeField] private Vector2Int _cellSize = Vector2Int.one * 16;

        [SerializeField] private Vector2Int _cursorAreaMin = Vector2Int.one * 16;
        [SerializeField] private Vector2Int _cursorAreaMax = Vector2Int.one * 208;

        // internal - framerate of a cursor position change 
        private float nextUpdateTime = 0.0f;
        [SerializeField] private float inputUpdateInterval = 1 / 30f;

        [SerializeField] private BlockType currentBlockPatternType = BlockType.Empty;

        // internal - gamepad button states
        private bool isUpPressed = false;
        private bool isDownPressed = false;
        private bool isLeftPressed = false;
        private bool isRightPressed = false;

        private bool isBPressed = false;
        private bool isAPressed = false;

        private bool wasCursorMoved = true;

        private Vector2Int CursorPosition { get { return _cursorPosition; } }
        private Vector2Int CurrentBlockIndex { get { return new Vector2Int(CursorPosition.x / _cellSize.x, CursorPosition.y / _cellSize.y); } }

        #region MonoBehaviours life cycle callbacks
        private void Awake()
        {
            this._gamepadEventsListener = this;
            Time.fixedDeltaTime = 1 / 60;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time > nextUpdateTime)
            {
                nextUpdateTime += inputUpdateInterval;

                if (isUpPressed)
                {
                    ChangeCursorPosition(0, _cellSize.y);
                }
                else if (isDownPressed)
                {
                    ChangeCursorPosition(0, -_cellSize.y);
                }

                if (isLeftPressed)
                {
                    ChangeCursorPosition(-_cellSize.x, 0);
                }
                else if (isRightPressed)
                {
                    ChangeCursorPosition(_cellSize.x, 0);
                }
            }
        }
        #endregion

        //
        // Implementation of abstract method
        //
        public override void Launch()
        {
            InitConstruction();
        }

        private void InitConstruction()
        {
            LoadTerrain();

            SetCursorPosition(_cursorInitialPosition.x, _cursorInitialPosition.y);

            _cursor.ChangeVisibility(true);
        }

        private void LoadTerrain()
        {
            StageController.Instance.SetCurrentStage(_constructionStage);
            StageController.Instance.FullfillStage();
        }

        /// <summary>
        /// Clamping position values to cursorAreaMin & Max
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SetCursorPosition(int x, int y)
        {
            _cursorPosition.x = Mathf.Clamp(x, _cursorAreaMin.x, _cursorAreaMax.x); 
            _cursorPosition.y = Mathf.Clamp(y, _cursorAreaMin.y, _cursorAreaMax.y);

            ApplyCursorPosition();
        }

        private void ChangeCursorPosition(int x, int y)
        {
            SetCursorPosition(CursorPosition.x + x, CursorPosition.y + y);

            wasCursorMoved = true;

            if (isAPressed || isBPressed)
            {
                ApplyBlockPattern();
            }
        }

        private void ApplyCursorPosition()
        {
            _cursor.SetPosition(_cursorPosition.x, _cursorPosition.y);
        }

        private void SwitchToNextPattern()
        {
            currentBlockPatternType++;
            currentBlockPatternType = (BlockType)((int)currentBlockPatternType % (int)BlockType.Count);

            //Debug.Log(name + " >> Switch to next pattern: " + currentBlockPatternType);
            // TODO: implement applying terrain to stage
        }

        private void SwitchToPreviousPattern()
        {
            currentBlockPatternType--;

            if (currentBlockPatternType < 0)
            {
                currentBlockPatternType = BlockType.Count - 1; // = (BlockType)((int)currentBlockPatternType % (int)BlockType.Count);
            }

            //Debug.Log(name + " >> Switch to previous pattern: " + currentBlockPatternType);
        }

        private void ApplyBlockPattern()
        {
            BlockPattern pattern = BlockPattern.GetPattern(currentBlockPatternType);

            UpdateQuarter(Quarter.NorthWest, pattern);
            UpdateQuarter(Quarter.NorthEast, pattern);
            UpdateQuarter(Quarter.SouthWest, pattern);
            UpdateQuarter(Quarter.SouthEast, pattern);
        }

        private Vector2Int BlockIndexAtCursorPosition
        {
            get
            {
                return new Vector2Int(CursorPosition.x / _cellSize.x, CursorPosition.y / _cellSize.y) * 2;
            }
        }

        private void UpdateQuarter(Quarter quarter, BlockPattern pattern)
        {
            TerrainType terrainType = pattern.GetTerrainTypeAt(quarter);

            Vector2Int quarterVector = StageUtils.GetQuarterVector2Int(quarter);
            Vector2Int fixedBlockIndex = BlockIndexAtCursorPosition + quarterVector;

            // Updates stage scriptable object
            _constructionStage.ModifyBlock(fixedBlockIndex.x, fixedBlockIndex.y, terrainType);
            _constructionStage.ApplyToAsset();

            // Updates visuals
            StageController.Instance.UpdateTerrainType(fixedBlockIndex.x, fixedBlockIndex.y, terrainType);
        }

        private void GetTerrainDataForUpload()
        {

            //Byte[] stageData = new Byte[_constructionStage.GridSizeY * _constructionStage.GridSizeX];
            for (int iRow = 0; iRow < _constructionStage.GridSizeY; iRow++)
            {
                for (int iColumn = 0; iColumn < _constructionStage.GridSizeX; iColumn++)
                {
                    //Debug.Log(">> TerrainType: " + (Byte)(_stage.GetTerrainType(iColumn, iRow)));

                    //stageData[iRow * _constructionStage.GridSizeX + iColumn] = (byte)_constructionStage.GetTerrainType(iColumn, iRow));

                  //  _constructionStage.GetTerrainType(iColumn, iRow);
                }
            } 

            
        }

        #region Gamepad Events listeners - SELECT & START
        public void OnSelectPressed(short data)
        {

        }

        public void OnSelectReleased(short data)
        {

        }

        public void OnStartPressed(short data)
        {
            _cursor.ChangeVisibility(false);

            GameAppController.Instance.ReturnToTitleScreen(GameplayMode.StageEditor);
        }

        public void OnStartReleased(short data)
        {

        }
        #endregion

        #region Gamepad Events listeners - UP & DOWN
        public void OnUpPressed(short data)
        {
            isUpPressed = true;
        }

        public void OnUpReleased(short data)
        {
            isUpPressed = false;
        }

        public void OnDownPressed(short data)
        {
            isDownPressed = true;
        }

        public void OnDownReleased(short data)
        {
            isDownPressed = false;
        }
        #endregion

        #region Gamepad Events listeners - LEFT & RIGHT
        public void OnLeftPressed(short data)
        {
            isLeftPressed = true;
        }

        public void OnLeftReleased(short data)
        {
            isLeftPressed = false;
        }

        public void OnRightPressed(short data)
        {
            isRightPressed = true;
        }

        public void OnRightReleased(short data)
        {
            isRightPressed = false;
        }
        #endregion

        #region Gamepad Events listeners - B & A
        public void OnBPressed(short data)
        {
            //Debug.Log(this.name + " >> On B pressed");
            if (!wasCursorMoved)
            {
                SwitchToNextPattern();
            }
            wasCursorMoved = false;

            ApplyBlockPattern();

            isBPressed = true;
        }

        public void OnBReleased(short data)
        {
            isBPressed = false;
            //Debug.Log(this.name + " >> On B released");
        }

        public void OnAPressed(short data)
        {
            if (!wasCursorMoved)
            {
                SwitchToPreviousPattern();
            }
            wasCursorMoved = false;

            //Debug.Log(this.name + " >> On A pressed");
            ApplyBlockPattern();

            isAPressed = true;
        }

        public void OnAReleased(short data)
        {
            isAPressed = false;
            //Debug.Log(this.name + " >> On A released");
        }
        #endregion
    }
}
