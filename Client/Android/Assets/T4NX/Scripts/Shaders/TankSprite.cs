using System;
using UnityEngine;

namespace T4NX
{
    public class TankSprite : MonoBehaviour
    {
        #region Inspector's fields
        [SerializeField] private int _FPS = 0;

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

        [SerializeField] private Color _colorA = Color.red;
        [SerializeField] private Color _colorB = Color.green;
        [SerializeField] private Color _colorC = Color.blue;

        /// <summary>
        /// Book of tank sprite frames
        /// </summary>
        [SerializeField] private Texture2D _EnemyBook;

        [SerializeField] public SpriteRenderer renderer;

        #endregion



        #region Public accessors
        /// <summary>
        /// Sets renderer sortingLayerID defined due ScreenLayers enum
        /// </summary>
        public ScreenLayers ScreenLayer
        {
            get
            {
                return (ScreenLayers)renderer.sortingLayerID;
            }
            set
            {
                renderer.sortingLayerID = SortingLayer.NameToID(value.ToString());
            }
        }

        /// <summary>
        /// Custom shader property
        /// </summary>
        public int FPS
        {
            get
            {
                return _FPS;
            }
            set
            {
                _FPS = value;
                material.SetFloat(nameof(TankSpriteReference._FPS), (float)_FPS);
            }
        }

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
                material.SetInt(nameof(TankSpriteReference._IsInMove), _isInMove ? 1 : 0);
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
                material.SetInt(nameof(TankSpriteReference._IsBlinking), _isBlinking ? 1 : 0);
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
                material.SetInt(nameof(TankSpriteReference._IsShining), _isShining ? 1 : 0);
            }
        }
        #endregion

        #region Private & protected accessors - Colors: ExtraA, ExtraB, ExtraC, A, B, C
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

        private Color AColor
        {
            set
            {
                _colorA = value;
                material.SetColor(nameof(TankSpriteReference._ColorA), value);
            }
            get
            {
                return _colorA;
            }
        }

        private Color BColor
        {
            set
            {
                _colorB = value;
                material.SetColor(nameof(TankSpriteReference._ColorB), value);
            }
            get
            {
                return _colorB;
            }
        }

        private Color CColor
        {
            set
            {
                _colorC = value;
                material.SetColor(nameof(TankSpriteReference._ColorC), value);
            }
            get
            {
                return _colorC;
            }
        }

        #endregion

        #region Private fields

        private Material material;

        #endregion

        #region MonoBehaviour's callbacks

        private void Awake()
        {
            InitShader();

            
        }

        private void Start()
        {
            //InitShader();
        }

        
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

        public void ApplyBaseColors(ScreenPalette.SpriteSubpalette spriteSubpalette)
        {
            //BaseColor = Color.white; // ScreenPalette.Instance.GetColor(spriteSubpalette.baseColorName);
            AColor = ScreenPalette.Instance.GetColor(spriteSubpalette.AColorName);
            BColor = ScreenPalette.Instance.GetColor(spriteSubpalette.BColorName);
            CColor = ScreenPalette.Instance.GetColor(spriteSubpalette.CColorName);
        }

        public void ApplyBaseColors(ColorName colorA, ColorName colorB, ColorName colorC)
        {
            //BaseColor = Color.white; //ScreenPalette.Instance.GetColor(terrainSubpalette.baseColorName);
            AColor = ScreenPalette.Instance.GetColor(colorA);
            BColor = ScreenPalette.Instance.GetColor(colorB); 
            CColor = ScreenPalette.Instance.GetColor(colorC);
        }

        public void ApplyBaseColors(int colorA, int colorB, int colorC)
        {
            //BaseColor = Color.white; //ScreenPalette.Instance.GetColor(terrainSubpalette.baseColorName);
            AColor = ScreenPalette.Instance.GetColor((ColorName)colorA);
            BColor = ScreenPalette.Instance.GetColor((ColorName)colorB);
            CColor = ScreenPalette.Instance.GetColor((ColorName)colorC);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isVisible"></param>
        public void ChangeVisibility(bool isVisible)
        {
            renderer.gameObject.SetActive(isVisible);
        }

        #endregion

        #region Private & protected methods

        protected void SetFloat(string name, float value)
        {
            material.SetFloat(name, value);
        }

        protected void ApplyDirection()
        {
            Debug.Log(name + " >>  ApplyDirection() " + TankDirection);

            material.SetInt(nameof(TankSpriteReference._IsUp), ShaderUtils.ShaderBool(TankDirection == Direction.North));
            material.SetInt(nameof(TankSpriteReference._IsDown), ShaderUtils.ShaderBool(TankDirection == Direction.South));
            material.SetInt(nameof(TankSpriteReference._IsLeft), ShaderUtils.ShaderBool(TankDirection == Direction.West));
            material.SetInt(nameof(TankSpriteReference._IsRight), ShaderUtils.ShaderBool(TankDirection == Direction.East));
        }

        private void InitShader()
        {
            //if (renderer == null)
            {
               // renderer = GetComponent<SpriteRenderer>();
            }
            material = renderer.material;
        }
        #endregion

    }
}
