using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace T4NX
{
    [CreateAssetMenu(fileName = "TankistProfile_", menuName = "Tankist/Profile", order = 3)]
    public class TankistProfileScriptableObject : ScriptableObject
    {
        [SerializeField] private string _tankistID;
        [SerializeField] private string _tankistName;
        [SerializeField] private TankistColor _tankistColorOption = TankistColor.Yellow;
        [SerializeField] private ScreenPalette.SpriteSubpalette _tankistColors;

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
        /// 
        /// </summary>
        public TankistColor TankistColorOption 
        { 
            get { return _tankistColorOption; } 
            set { _tankistColorOption = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ScreenPalette.SpriteSubpalette TankistColors
        {
            get { return _tankistColors; }
            set { _tankistColors = value; }
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
