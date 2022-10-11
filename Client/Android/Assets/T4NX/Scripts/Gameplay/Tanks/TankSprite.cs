using System;
using UnityEngine;

namespace T4NX
{
    public class TankSprite : CustomSprite
    {
        #region Inspector's fields
        [SerializeField] private int _Level = 0;

        [SerializeField] private Direction _tankDirection;

        [SerializeField] private bool _IsUp = false;
        [SerializeField] private bool _IsDown = false;
        [SerializeField] private bool _IsLeft = false;
        [SerializeField] private bool _IsRight = false;

        [SerializeField] private bool _isInMove = false;
        [SerializeField] private bool _isBlinking = false;
        [SerializeField] private bool _isShining = false;

        [SerializeField] private Color _extraColorA = Color.red;
        [SerializeField] private Color _extraColorB = Color.green;
        [SerializeField] private Color _extraColorC = Color.blue;

        /// <summary>
        /// Book of tank sprite frames
        /// </summary>
        [SerializeField] private Texture2D _EnemyBook;

        #endregion

        #region Public accessors
       

        
        /// <summary>
        /// Armor level
        /// </summary>
        public int Level
        {
            get
            {
                return _Level;
            }
            set
            {
                _Level = value;
                material.SetFloat(nameof(TankSpriteReference._Level), (float)_Level);
            }
        }

        /// <summary>
        /// Sets tank direction and applies to referenced shader
        /// </summary>
        public Direction TankDirection
        {
            get
            {
                return _tankDirection;
            }
            set
            {
                _tankDirection = value;
                ApplyDirection();
            }
        }

        public bool IsInMove
        {
            get
            {
                return _isInMove;
            }
            set
            {
                _isInMove = value;
                material.SetInt(nameof(TankSpriteReference._IsInMove), ShaderUtils.ShaderBool(_isInMove));
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
                material.SetInt(nameof(TankSpriteReference._IsBlinking), ShaderUtils.ShaderBool(_isBlinking));
            }
        }

        public bool IsShining
        {
            get
            {
                return _isShining;
            }
            set
            {
                _isShining = value;
                material.SetInt(nameof(TankSpriteReference._IsShining), ShaderUtils.ShaderBool(_isShining));
            }
        }
        #endregion

        #region Private & protected accessors - Colors: ExtraA, ExtraB, ExtraC
        private Color ExtraAColor
        {
            set
            {
                _extraColorA = value;
                material.SetColor(nameof(TankSpriteReference._ExtraColorA), value);
            }
            get
            {
                return _extraColorA;
            }
        }

        private Color ExtraBColor
        {
            set
            {
                _extraColorB = value;
                material.SetColor(nameof(TankSpriteReference._ExtraColorB), value);
            }
            get
            {
                return _extraColorB;
            }
        }

        private Color ExtraCColor
        {
            set
            {
                _extraColorC = value;
                material.SetColor(nameof(TankSpriteReference._ExtraColorC), value);
            }
            get
            {
                return _extraColorC;
            }
        }
        #endregion

        #region Private fields

        

        #endregion

        #region MonoBehaviour's callbacks




        #endregion

        #region Public methods
        public void ApplyExtraColors(ScreenPalette.SpriteSubpalette spriteSubpalette)
        {
            ExtraAColor = ScreenPalette.Instance.GetColor(spriteSubpalette.AColorName);
            ExtraBColor = ScreenPalette.Instance.GetColor(spriteSubpalette.BColorName);
            ExtraCColor = ScreenPalette.Instance.GetColor(spriteSubpalette.CColorName);
        }

        public void ApplyExtraColors(ColorName colorA, ColorName colorB, ColorName colorC)
        {
            ExtraAColor = ScreenPalette.Instance.GetColor(colorA);
            ExtraBColor = ScreenPalette.Instance.GetColor(colorB);
            ExtraCColor = ScreenPalette.Instance.GetColor(colorC);
        }

        public void ApplyExtraColors(int colorA, int colorB, int colorC)
        {
            ExtraAColor = ScreenPalette.Instance.GetColor((ColorName)colorA);
            ExtraBColor = ScreenPalette.Instance.GetColor((ColorName)colorB);
            ExtraCColor = ScreenPalette.Instance.GetColor((ColorName)colorC);
        }
        #endregion

        #region Protected & private methods
        protected void ApplyDirection()
        {
            Debug.Log(name + " >>  ApplyDirection() " + TankDirection);

            SetBool(nameof(TankSpriteReference._IsUp), TankDirection == Direction.North);
            SetBool(nameof(TankSpriteReference._IsDown), TankDirection == Direction.South);
            SetBool(nameof(TankSpriteReference._IsLeft), TankDirection == Direction.West);
            SetBool(nameof(TankSpriteReference._IsRight), TankDirection == Direction.East);

            /*
            material.SetInt(nameof(TankSpriteReference._IsUp), ShaderUtils.ShaderBool(TankDirection == Direction.North));
            material.SetInt(nameof(TankSpriteReference._IsDown), ShaderUtils.ShaderBool(TankDirection == Direction.South));
            material.SetInt(nameof(TankSpriteReference._IsLeft), ShaderUtils.ShaderBool(TankDirection == Direction.West));
            material.SetInt(nameof(TankSpriteReference._IsRight), ShaderUtils.ShaderBool(TankDirection == Direction.East));
            */
        }

       
        #endregion

    }
}
