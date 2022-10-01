using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static T4NX.ScreenFader;

namespace T4NX
{
    public class StageSelector : MonoSingleton<StageSelector>, IGamepadEventsListener
    {
        [SerializeField] private string selectedStagePrefix = "STAGE ";
        [SerializeField] private int _currentStageIndex = 0;

        [SerializeField] private TextMeshProUGUI _selectedStageLabel;
        [SerializeField] private List<StageScriptableObject> stageScriptableObject;

        [SerializeField] private int CurrentStageLimit
        {
            get 
            { 
                return 35; 
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
        public void OnSelectPressed(short data)
        {


        }

        public void OnSelectReleased(short data)
        {

        }

        public void OnStartPressed(short data)
        {
            if (ScreenFader.Instance.IsOpen) // unactive
            {

            }
            else
            {
                _selectedStageLabel.enabled = false; //.gameObject.SetActive(false);
                ScreenFader.Instance.Open(LaunchGameplayMode);
            }
        }

        public void OnStartReleased(short data)
        {

        }
        #endregion

        #region Gamepad Events listeners - UP & DOWN
        public void OnUpPressed(short data)
        {
            //isUpPressed = true;
        }

        public void OnUpReleased(short data)
        {
            //isUpPressed = false;
        }

        public void OnDownPressed(short data)
        {
            //isDownPressed = true;
        }

        public void OnDownReleased(short data)
        {
            //isDownPressed = false;
        }
        #endregion

        #region Gamepad Events listeners - LEFT & RIGHT
        public void OnLeftPressed(short data)
        {
            //isLeftPressed = true;
        }

        public void OnLeftReleased(short data)
        {
            //isLeftPressed = false;
        }

        public void OnRightPressed(short data)
        {
            //isRightPressed = true;
        }

        public void OnRightReleased(short data)
        {
            //isRightPressed = false;
        }
        #endregion

        #region Gamepad Events listeners - B & A
        public void OnBPressed(short data)
        {
            isBPressed = true;

            
        }

        public void OnBReleased(short data)
        {

            isBPressed = false;
            //Debug.Log(this.name + " >> On B released");
        }

        public void OnAPressed(short data)
        {
            isAPressed = true;
        }

        public void OnAReleased(short data)
        {
            isAPressed = false;
            //Debug.Log(this.name + " >> On A released");
        }
        #endregion

        private void SetupGamepadListeners()
        {
            GamepadEventsManager.Instance.SetupListeners(this);
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
        /// Starts currently selected gameplay mode
        /// </summary>
        private void LaunchGameplayMode()
        {
            Debug.Log(name + " >> LaunchGameplayMode() GameplayMode: " + GameplayMenu.Instance.CurrentlySelectedGameplayMode);

            GamepadEventsManager.Instance.SetupListeners(GameplayMenu.Instance.CurrentGameplayController.GamepadEventsListener);

            GameplayMenu.Instance.CurrentGameplayController.Launch();
        }

    }
}
