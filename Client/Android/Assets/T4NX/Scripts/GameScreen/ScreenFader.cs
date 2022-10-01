using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace T4NX
{
    public class ScreenFader : MonoSingleton<ScreenFader>
    {
        [SerializeField] private float animationDuration = 1.0f;

        [SerializeField] private Transform northFrame;
        [SerializeField] private Transform southFrame;

        [SerializeField] private int northFrameShiftOpen = 240;
        [SerializeField] private int northFrameShiftClose = 120; 
        
        [SerializeField] private int southFrameShiftOpen = -120;
        [SerializeField] private int southFrameShiftClose = 0;

        private bool isOpen = true;


        private void Awake()
        {
            InitFrames();
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
            northFrame.DOMoveY(northFrameShiftOpen, animationDuration, true);
            southFrame.DOMoveY(southFrameShiftOpen, animationDuration, true);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            northFrame.DOMoveY(northFrameShiftClose, animationDuration, true);
            southFrame.DOMoveY(southFrameShiftClose, animationDuration, true);
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
            northFrame.position = new Vector3(0, isOpen ? northFrameShiftOpen : northFrameShiftClose);
            southFrame.position = new Vector3(0, isOpen ? southFrameShiftOpen : southFrameShiftClose);
        }
    }
}
