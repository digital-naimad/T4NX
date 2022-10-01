using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class Tankist : MonoBehaviour
    {
        [SerializeField] private string tankerName;
        [SerializeField] private TankistColor tankerColorOption = TankistColor.Yellow;
        [SerializeField] private ScreenPalette.SpriteSubpalette _tankerColors;
        [SerializeField] private TankController _tank = null;

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
