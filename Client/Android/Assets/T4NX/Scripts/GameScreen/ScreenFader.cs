using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static T4NX.ScreenShifter;

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

        public delegate void OnClosingCompletedCallback();
        public delegate void OnOpeningCompletedCallback();

        /// <summary>
        /// 
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
        }

        private Tween northOpenTween;
        private Tween southOpenTween;

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
        public void Open(OnOpeningCompletedCallback onCompleteCallback)
        {
            ApplyFramesPositions();
            ShowFrames();

            northOpenTween = northFrame.DOMoveY(northFrameShiftOpen, animationDuration, true);
            northOpenTween.SetEase(Ease.Linear);
            northOpenTween.Play();

            southOpenTween = southFrame.DOMoveY(southFrameShiftOpen, animationDuration, true);
            southOpenTween.SetEase(Ease.Linear);
            southOpenTween.OnComplete(() => onCompleteCallback());
            southOpenTween.Play();

            // TODO: setup callback?
            _isOpen = true;

        }

        /// <summary>
        /// 
        /// </summary>
        public void Close(OnClosingCompletedCallback onCompleteCallback)
        {
            ApplyFramesPositions();
            ShowFrames();

            northOpenTween = northFrame.DOMoveY(northFrameShiftClose, animationDuration, true);
            northOpenTween.SetEase(Ease.Linear);
            northOpenTween.Play();

            southOpenTween = southFrame.DOMoveY(southFrameShiftClose, animationDuration, true);
            southOpenTween.SetEase(Ease.Linear);
            southOpenTween.OnComplete(() => onCompleteCallback());
            southOpenTween.Play();

            // TODO: setup callback?
            _isOpen = false;
        }

        private void ShowFrames()
        {
            // NORTH FRAME
            northFrame.gameObject.SetActive(true);

            // SOUTH FRAME
            southFrame.gameObject.SetActive(true);
        }

        private void ApplyFramesPositions()
        {
            northFrame.position = new Vector3(0, _isOpen ? northFrameShiftOpen : northFrameShiftClose);
            southFrame.position = new Vector3(0, _isOpen ? southFrameShiftOpen : southFrameShiftClose);
        }
    }
}
