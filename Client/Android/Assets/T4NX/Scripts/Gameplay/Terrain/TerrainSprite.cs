using System;
using UnityEngine;

namespace T4NX
{
    public class TerrainSprite : CustomSprite
    {
        #region Inspector's fields
        [SerializeField] private bool _isBlinking = false;

        [SerializeField] private Vector4 _mask = Vector4.zero;

        [SerializeField] private Color _baseColor = Color.white;

        [SerializeField] private int _noOfFrames = 2;
        [SerializeField] private int _bookSize = 6;
        #endregion

        #region Public accessor properties

        /// <summary>
        /// [0, 0, 0, 0]
        /// </summary>
        public Vector4 Mask
        {
            get
            {
                return _mask;
            }
            set
            {
                //Debug.Log(name + " >> Sets mask " + value);
                _mask = value;
                SetVector(nameof(TerrainSpriteReference._Mask), value);
            }
        }

        public bool IsBlinking
        {
            get
            {
                return _isBlinking;
            }
            set
            {
                _isBlinking = value;
                material.SetInt(nameof(TerrainSpriteReference._IsBlinking), ShaderUtils.ShaderBool(_isBlinking));
            }
        }

        #endregion

        #region Protected & private properties

        protected Color BaseColor
        {
            set
            {
                _baseColor = value;
                material.SetColor(nameof(TerrainSpriteReference._BaseColor), value);
            }
            get
            {
                return _baseColor;
            }
        }

        #endregion




        #region Public methods

       
        #endregion

        #region Protected & private methods



        #endregion


    }
}
