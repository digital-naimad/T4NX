using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class AnimatedSprite : CustomSprite
    {
        #region Inspector's fields
        [SerializeField] private int _NumberOfRows;

        [SerializeField] private bool _IsLooped;

        [SerializeField] private Color _BaseColor;

        #endregion

        #region Public acccessors

        /// <summary>
        /// Custom shader property (number of rows in _Frames book)
        /// </summary>
        public int NumberOfRows
        {
            get
            {
                return _NumberOfRows;
            }
            set
            {
                _NumberOfRows = value;
                SetInt(nameof(AnimatedSpriteReferences._NumberOfRows), _NumberOfRows);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsLooped
        {
            get
            {
                return _IsLooped;
            }
            set
            {
                _IsLooped = value;
                SetBool(nameof(AnimatedSpriteReferences._IsLooped), _IsLooped);
            }
        }

        #endregion

        #region Protected & private accessor properties

        protected Color BaseColor
        {
            set
            {
                _BaseColor = value;
                SetColor(nameof(AnimatedSpriteReferences._BaseColor), value);
            }
            get
            {
                return _BaseColor;
            }
        }

        #endregion

        #region Private fields


        #endregion

        #region Public methods
        /// <summary>
        /// 
        /// </summary>
        public void Play()
        {

        }
        #endregion

      

    }
}
