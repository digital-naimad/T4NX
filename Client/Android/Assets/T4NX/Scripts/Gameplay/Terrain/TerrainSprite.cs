using System;
using UnityEngine;

namespace T4NX
{
    public class TerrainSprite : CustomSprite
    {
        #region Inspector's fields
        [SerializeField] private bool _IsBlinking = false;

        [SerializeField] private Vector4 _Mask = Vector4.zero;

        [SerializeField] private Color _BaseColor = Color.white;

        [SerializeField] private int _BookSize = 6;
        #endregion

        #region Public accessor properties

        /// <summary>
        /// [0, 0, 0, 0]
        /// </summary>
        public Vector4 Mask
        {
            get
            {
                return _Mask;
            }
            set
            {
                //Debug.Log(name + " >> Sets mask " + value);
                _Mask = value;
                SetVector(nameof(TerrainSpriteReferences._Mask), value);
            }
        }

        public bool IsBlinking
        {
            get
            {
                return _IsBlinking;
            }
            set
            {
                _IsBlinking = value;
                SetBool(nameof(TerrainSpriteReferences._IsBlinking), _IsBlinking);
            }
        }

        #endregion

        #region Protected & private accessor properties

        protected Color BaseColor
        {
            set
            {
                _BaseColor = value;
                SpriteMaterial.SetColor(nameof(TerrainSpriteReferences._BaseColor), value);
            }
            get
            {
                return _BaseColor;
            }
        }

        #endregion

        


        #region Public methods


        #endregion

        #region Protected & private methods



        #endregion


    }
}
