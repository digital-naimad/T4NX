using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace T4NX
{
    public class CustomSprite : MonoBehaviour
    {
        #region Inspector's fields
        [SerializeField] private int _FPS = 0;

        [SerializeField] protected Color _colorA = Color.red;
        [SerializeField] protected Color _colorB = Color.green;
        [SerializeField] protected Color _colorC = Color.blue;

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
        /// Custom shader property (framerate of animation, blinking etc.)
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
                SetFloat(nameof(CustomSpriteReferences._FPS), _FPS);
            }
        }

        #endregion

        #region Private & protected accessors - Colors: A, B, C
        private Color AColor
        {
            set
            {
                _colorA = value;
                SetColor(nameof(CustomSpriteReferences._ColorA), value);
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
                SetColor(nameof(CustomSpriteReferences._ColorB), value);
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
                SetColor(nameof(CustomSpriteReferences._ColorC), value);
            }
            get
            {
                return _colorC;
            }
        }

        #endregion

        #region Protected and private fields

        protected Material material;

        #endregion

        #region MonoBehaviour's callbacks

        private void Awake()
        {
            InitShader();

        }

        #endregion

        #region Public methods
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

        #region Protected & private methods

        
        protected void SetInt(string parameterName, int intValue)
        {
            material.SetFloat(parameterName, intValue);
        }

        protected void SetBool(string parameterName, bool booleanValue)
        {
            material.SetInt(parameterName, ShaderUtils.ShaderBool(booleanValue));
        }

        protected void SetFloat(string parameterName, float floatValue)
        {
            material.SetFloat(parameterName, floatValue);
        }

        protected void SetVector(string parameterName, Vector4 vector4Value)
        {
            material.SetVector(parameterName, vector4Value);
        }

        protected void SetColor(string parameterName, Color colorValue)
        {
            material.SetColor(parameterName, colorValue);
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
