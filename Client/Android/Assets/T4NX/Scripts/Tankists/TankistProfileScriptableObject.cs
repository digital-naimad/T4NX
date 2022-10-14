using UnityEngine;
using UnityEditor;

namespace T4NX
{
    [CreateAssetMenu(fileName = "TankistProfile_", menuName = "Tankist/Profile", order = 3)]
    public class TankistProfileScriptableObject : ScriptableObject
    {
        [SerializeField] private string _tankistID;
        [SerializeField] private string _tankistName;

        [SerializeField] private TankistColorsPreset _colorsPreset;
        

        [SerializeField] private AccessProfileScriptableObject _accessProfile;

        #region Public accessors
        /// <summary>
        /// 
        /// </summary>
        public string TankistID
        {
            get { return _tankistID; }
            set { _tankistID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TankistName
        {
            get { return _tankistName; }
            set { _tankistName = value; }
        }
        /// <summary>
        /// Getter only
        /// </summary>
        public TankistColorsPreset ColorsPreset 
        { 
            get { return _colorsPreset; } 
            
        }

        /// <summary>
        /// Getter only
        /// </summary>
        public TankistColor TankistColors
        {
            get { return ColorsPreset.TankistColorOption; }
        }

        /// <summary>
        /// Getter only
        /// </summary>
        public ScreenPalette.SpriteSubpalette Subpalette
        {
            get { return ColorsPreset.TankistColors; }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public AccessProfileScriptableObject AccessProfile
        {
            get { return _accessProfile; }
            set { _accessProfile = value; }
        }

        #endregion

        public TankistProfileScriptableObject()
        {
            //Debug.Log(name + " >> CALLS CONSTRUCTOR");
           
        }

        private void Awake()
        {
            //Debug.Log((name + " >> StageScriptableObject Awake() call");
            
        }

        #region Public methods

        public void ApplyToAsset()
        {
            
#if UNITY_EDITOR


            EditorUtility.SetDirty(this);
    
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
#endif
            
        }
        #endregion
    }
}
