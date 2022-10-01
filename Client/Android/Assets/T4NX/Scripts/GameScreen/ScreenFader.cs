using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace T4NX
{
    public class ScreenFader : MonoSingleton<ScreenFader>
    {
        [SerializeField] private bool _isOpen = true;

        [SerializeField] private Transform northFrame;
        [SerializeField] private Transform southFrame;

        [SerializeField] private int northFrameShiftOpen = 240;
        [SerializeField] private int northFrameShiftClose = 120; 
        
        [SerializeField] private int southFrameShiftOpen = -120;
        [SerializeField] private int southFrameShiftClose = 0;

        [SerializeField] private float animationDuration = 1.0f;

        private bool IsOpen 
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
                //ApplyFramesPositions();
            }
        }


        private void Awake()
        {
            //InitFrames();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void Open()
        {
            ApplyFramesPositions();

            northFrame.DOMoveY(northFrameShiftOpen, animationDuration, true);
            southFrame.DOMoveY(southFrameShiftOpen, animationDuration, true);

            // TODO: setup callback?
            IsOpen = true;

        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            ApplyFramesPositions();

            northFrame.DOMoveY(northFrameShiftClose, animationDuration, true);
            southFrame.DOMoveY(southFrameShiftClose, animationDuration, true);
            // TODO: setup callback?
            IsOpen = false;
        }

        private void InitFrames()
        {
            // NORTH FRAME
            northFrame.gameObject.SetActive(true);

            // SOUTH FRAME
            southFrame.gameObject.SetActive(true);

            ApplyFramesPositions();
        }

        private void ApplyFramesPositions()
        {
            northFrame.position = new Vector3(0, IsOpen ? northFrameShiftOpen : northFrameShiftClose);
            southFrame.position = new Vector3(0, IsOpen ? southFrameShiftOpen : southFrameShiftClose);
        }
    }
}
