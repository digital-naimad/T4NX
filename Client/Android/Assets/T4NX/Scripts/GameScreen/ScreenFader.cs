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

        [SerializeField] private Transform coverFrameRoot;

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
            ApplyBlindsPositions();
            ShowBlinds();
            ShowCoverFrame();

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
            ApplyBlindsPositions();
            ShowBlinds();
            HideCoverFrame();

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

        private void ShowBlinds()
        {
            // NORTH FRAME
            northFrame.gameObject.SetActive(true);

            // SOUTH FRAME
            southFrame.gameObject.SetActive(true);
        }

        private void ApplyBlindsPositions()
        {
            northFrame.position = new Vector3(0, _isOpen ? northFrameShiftOpen : northFrameShiftClose);
            southFrame.position = new Vector3(0, _isOpen ? southFrameShiftOpen : southFrameShiftClose);
        }

        private void ShowCoverFrame()
        {
            coverFrameRoot.gameObject.SetActive(true);
        }

        private void HideCoverFrame()
        {
            coverFrameRoot.gameObject.SetActive(false);
        }
    }
}
