using UnityEngine;
using DG.Tweening;

namespace T4NX
{
    public class ScreenShifter : MonoSingleton<ScreenShifter>
    {
        [SerializeField] private int initPositionY = -240;
        [SerializeField] private int finalPositionY = 0;

        [SerializeField] private float animationDuration = 4.0f;

        public delegate void OnMoveInCompletedCallback();

        /// <summary>
        /// 
        /// </summary>
        public bool IsShiftEnded
        {
            get 
            { 
                return isShiftEnded; 
            }
        }

        private bool isShiftEnded = false;
        private Tween moveTween;

        private void Awake()
        {
            ApplyInitPosition();
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
        public void MoveIn(OnMoveInCompletedCallback onCompleteCallback)
        {
            moveTween = transform.DOMoveY(finalPositionY, animationDuration, true);
            moveTween.SetEase(Ease.Linear);
            moveTween.OnComplete(() => { isShiftEnded = true; });
            moveTween.OnComplete(() => onCompleteCallback());
            moveTween.Play();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ForceEnd()
        {
            moveTween.Complete();
            isShiftEnded = true;
        }

        private void ApplyInitPosition()
        {
            transform.position = new Vector3(0, initPositionY);
        }
    }

}