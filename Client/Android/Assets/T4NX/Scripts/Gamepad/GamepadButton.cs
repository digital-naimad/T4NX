using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace T4NX
{
    public class GamepadButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private bool _isPressed = false;

        [SerializeField] private GamepadEvent _eventPressed;
        [SerializeField] private GamepadEvent _eventReleased;

        public bool IsPressed
        {
            get 
            { 
                return _isPressed; 
            }
        }
        

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //Detect if a click occurs
        public void OnPointerClick(PointerEventData pointerEventData)
        {
            //Use this to tell when the user right-clicks on the Button
            //if (pointerEventData.button == PointerEventData.InputButton.Right)
            {
                //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
                //Debug.Log(name + " Game Object Right Clicked!");
            }

            //Use this to tell when the user left-clicks on the Button
            //if (pointerEventData.button == PointerEventData.InputButton.Left)
            {
                //Debug.Log(name + " Game Object Left Clicked!");
            }

            //GamepadEventsManager.Instance.DispatchEvent(_eventReleased);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
            //throw new System.NotImplementedException();

            //////Use this to tell when the user right-clicks on the Button
            //if (pointerEventData.button == PointerEventData.InputButton.Right)
            {
                //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
                //Debug.Log(name + " >> Game Object pointer down");
            }

            GamepadEventsManager.Instance.DispatchEvent(_eventPressed);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            {
                _isPressed = false;
                GamepadEventsManager.Instance.DispatchEvent(_eventReleased);

                //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
                //Debug.Log(name + " >> Game Object pointer up!");

            }
        }
    }
}
