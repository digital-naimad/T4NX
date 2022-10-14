using UnityEngine;

namespace T4NX
{
    public class Tankist : MonoBehaviour
    {
        [SerializeField] private TankistProfileScriptableObject _tankistProfile;

        public TankistProfileScriptableObject ProfileData { get { return _tankistProfile; } }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ApplyColorsToTank()
        {
            //if (_tankerColors)
            //_tank.ApplyColors(_tankerColors);
        }
    }
}
