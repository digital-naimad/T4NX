using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace T4NX
{
    public class BlockButton : MonoBehaviour
    {
        [SerializeField] private TerrainType currentTerrainType = TerrainType.Empty;
        [SerializeField] private Button blockButton;

        [SerializeField] private Sprite[] terrainImages;
        [SerializeField] private TextMeshProUGUI buttonText;

        public TerrainType CurrentTerrainType
        { 
            get 
            { 
                return currentTerrainType; 
            } 
            set
            {
                currentTerrainType = value;
                UpdateButtonImage();
                UpdateButtonText();
            }
        }

        public Vector2Int PositionOnGrid
        {
            get
            {
                return _positionOnGrid;
            }
        }

        private Vector2Int _positionOnGrid;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetupPositionOnGrid(int x, int y)
        {
            _positionOnGrid = new Vector2Int(x, y);
        }
        

        public void OnButtonClick()
        {
            Debug.Log("BUTTON CLICK >> row: " + PositionOnGrid.y + " column: " + PositionOnGrid.x + " type:" + currentTerrainType);

            currentTerrainType++;
            currentTerrainType = (TerrainType)((int)currentTerrainType % (int)TerrainType.Empty);

            UpdateButtonImage();
            UpdateButtonText();

            Debug.Log(name + " >>  OnButtonClick()" + currentTerrainType);

            StageEditor.Instance.ChangeBlock(_positionOnGrid, currentTerrainType);
        }

        private void UpdateButtonImage()
        {
            blockButton.image.sprite = terrainImages[(int)currentTerrainType];
        }

        private void UpdateButtonText()
        {
            //buttonText.text = "" + StageUtils.ConvertTerrainTypeToChar(currentTerrainType);
        }
    }
}
