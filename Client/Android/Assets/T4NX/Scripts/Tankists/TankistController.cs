using UnityEngine;

namespace T4NX
{
    public class TankistController : MonoBehaviour
    {
        [SerializeField] private TankistProfileData _tankistProfile;

        [SerializeField] private TankController _ownedTank;

        #region Public access

        public TankistProfileData ProfileData { get { return _tankistProfile; } }

        public TankistColorsPreset ColorsPreset { get { return _tankistProfile.ColorsPreset; } }

       

        /// <summary>
        /// Returns tankController of the tank currently owned by this Tankist
        /// </summary>
        public TankController OwnedTank { get { return _ownedTank; } }

        #endregion

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
        /// <param name="profileData"></param>
        public void ApplyProfile(TankistProfileData profileData)
        {
            _tankistProfile = profileData;

            //ApplyTankistName();
            ApplyColorsToTank();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ApplyTankistName()
        {
            GameplayMenu.Instance.UpdateTankistName(ProfileData.TankistName);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ApplyColorsToTank()
        {
            GameplayMenu.Instance.UpdateTankistAvatar(ColorsPreset.TankistColors);
        }

        
        #endregion
    }
}
