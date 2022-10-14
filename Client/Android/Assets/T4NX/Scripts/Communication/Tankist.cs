using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class Tankist : MonoBehaviour
    {
        [SerializeField] private TankistProfileScriptableObject _tankistProfile;

        public TankistProfileScriptableObject tankistProfile { get { return _tankistProfile; } }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void ApplyTankerColorsToTank()
        {
            //if (_tankerColors)
            //_tank.ApplyColors(_tankerColors);
        }
    }
}
