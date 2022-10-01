using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace T4NX
{

    public class TitleScreenController : MonoSingleton<TitleScreenController>
    {
        [SerializeField] private Canvas titleScreenCanvas;
        [SerializeField] private GameObject titleScreenContainer;

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
        public void Show(bool isAnimationInstant = true)
        {
            // TODO: setup Tweener
            //titleScreenCanvas.enabled = true;
            //titleScreenCanvas.gameObject.SetActive(true);
            titleScreenContainer.SetActive(true);

        }

        /// <summary>
        /// 
        /// </summary>
        public void Hide()
        {
            //titleScreenCanvas.enabled = false;
            //titleScreenCanvas.gameObject.SetActive(false);
            titleScreenContainer.SetActive(false);
        }
    }
}
