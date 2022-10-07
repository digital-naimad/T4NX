using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace T4NX
{
    public class StageSelector : MonoSingleton<StageSelector>, IGamepadEventsListener
    {
        [SerializeField] private string selectedStagePrefix = "STAGE ";
        [SerializeField] private int _currentStageIndex = 0;

        [SerializeField] private TextMeshProUGUI _selectedStageLabel;
        [SerializeField] private List<StageScriptableObject> stagesList = new List<StageScriptableObject>();

        [SerializeField] private int CurrentStageLimit
        {
            get 
            {
                return stagesList.Count; // 35; 
            }
        } 

        private bool isAPressed = false;
        private bool isBPressed = false;

        // internal - framerate of a cursor position change 
        private float nextUpdateTime = 0.0f;
        [SerializeField] private float inputUpdateInterval = .1f;

        private void Awake()
        {
            
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

                if (isAPressed)
                {
                    IncrementStageIndex();
                    UpdateCurrentStageLabel();
                } 
                else if (isBPressed)
                {
                    DecrementStageIndex();
                    UpdateCurrentStageLabel();
                }
            }
        }

        /// <summary>
        /// Closes fader and setups gamepad listeners
        /// </summary>
        public void Launch()
        {
            ScreenFader.Instance.Close(() => SetupGamepadListeners());
            _selectedStageLabel.enabled = true;// .gameObject.SetActive(true);
        }

        /// <summary>
        /// 
        /// </summary>
        //public void Hide()
       // {
        //    ScreenFader.Instance.Open(() => { });
       // }

        public void UpdateCurrentStageLabel()
        {
            _selectedStageLabel.text = selectedStagePrefix + (_currentStageIndex + 1);
        }



        #region Gamepad Events listeners - SELECT & START
        public void OnSelectPressed(params int[] data)
        {


        }

        public void OnSelectReleased(params int[] data)
        {

        }

        public void OnStartPressed(params int[] data)
        {
            if (ScreenFader.Instance.IsOpen) // unactive
            {

            }
            else
            {
                _selectedStageLabel.enabled = false; //.gameObject.SetActive(false);

                // TODO: load stage 
                if (StageController.Instance.WasStageModifiedByConstruction)
                {
                    // TODO: send stage to the server?
                    ScreenFader.Instance.Open(() => GameAppController.Instance.LaunchSelectedGameplayMode());
                }
                else
                {
                    StageController.Instance.SetCurrentStage(stagesList[_currentStageIndex]);
                    StageController.Instance.FullfillStage();
                    ScreenFader.Instance.Open(() => GameAppController.Instance.LaunchSelectedGameplayMode());
                }
            }
        }

        public void OnStartReleased(params int[] data)
        {

        }
        #endregion

        #region Gamepad Events listeners - UP & DOWN
        public void OnUpPressed(params int[] data)
        {
            //isUpPressed = true;
        }

        public void OnUpReleased(params int[] data)
        {
            //isUpPressed = false;
        }

        public void OnDownPressed(params int[] data)
        {
            //isDownPressed = true;
        }

        public void OnDownReleased(params int[] data)
        {
            //isDownPressed = false;
        }
        #endregion

        #region Gamepad Events listeners - LEFT & RIGHT
        public void OnLeftPressed(params int[] data)
        {
            //isLeftPressed = true;
        }

        public void OnLeftReleased(params int[] data)
        {
            //isLeftPressed = false;
        }

        public void OnRightPressed(params int[] data)
        {
            //isRightPressed = true;
        }

        public void OnRightReleased(params int[] data)
        {
            //isRightPressed = false;
        }
        #endregion

        #region Gamepad Events listeners - B & A
        public void OnBPressed(params int[] data)
        {
            isBPressed = true;

            
        }

        public void OnBReleased(params int[] data)
        {

            isBPressed = false;
            //Debug.Log(this.name + " >> On B released");
        }

        public void OnAPressed(params int[] data)
        {
            isAPressed = true;
        }

        public void OnAReleased(params int[] data)
        {
            isAPressed = false;
            //Debug.Log(this.name + " >> On A released");
        }
        #endregion

        private void SetupGamepadListeners()
        {
            //((GamepadEventsManager)GamepadEventsManager.Instance).SetupListeners(this);
            GamepadEventsManager.SetupListeners(this);
        }

        private void IncrementStageIndex()
        {
            _currentStageIndex = Mathf.Clamp(_currentStageIndex + 1, 0, CurrentStageLimit - 1);
        }

        private void DecrementStageIndex()
        {
            _currentStageIndex = Mathf.Clamp(_currentStageIndex - 1, 0, CurrentStageLimit - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns>null if there is no any StageScriptableObject in the list</returns>
        private StageScriptableObject GetStageData(int index)
        {
            if (stagesList.Count == 0)
            {
                return null;
            }

            return stagesList[index];
        }
    }
}
