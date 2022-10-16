using UnityEngine;

namespace T4NX
{
    public class TankistsManager : MonoSingleton<TankistsManager>
    {
        [SerializeField] private TankistController _firstTankist;
        [SerializeField] private TankistController _secondTankist;

        [SerializeField] private TankistProfileData[] _tankistsProfiles;

        private byte _currentProfileIndex = 0;

        #region MonoBehaviours stuff
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Public methods

        /// <summary>
        /// 
        /// </summary>
        public void SwitchToNextProfile()
        {
            _currentProfileIndex++;
            _currentProfileIndex %= (byte)_tankistsProfiles.Length;
            ApplyProfile();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SwitchToPreviousProfile()
        {
            _currentProfileIndex--;
            _currentProfileIndex %= (byte)_tankistsProfiles.Length;
            ApplyProfile();
        }
        #endregion

        #region Private methods
        private void ApplyProfile()
        {
            _firstTankist.ApplyProfile(_tankistsProfiles[_currentProfileIndex]);
        }
        #endregion

    }
}
