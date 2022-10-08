using System;
using UnityEngine;

namespace T4NX
{
    public class TankSprite : MonoBehaviour
    {
        [SerializeField] private int _FPS = 0;

        [SerializeField] private bool _isBlinking = false;

        [SerializeField] private Vector4 _mask = Vector4.zero;

        [SerializeField] private Color _baseColor = Color.white;
        [SerializeField] private Color _colorA = Color.red;
        [SerializeField] private Color _colorB = Color.green;
        [SerializeField] private Color _colorC = Color.blue;

        [SerializeField] private int _noOfFrames = 2;
        [SerializeField] private int _bookSize = 6;

        [SerializeField] public SpriteRenderer renderer;
        private Material material;

        //private Material material { get { return renderer.material; } }


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
                material.SetVector(TerrainBlockReference._Mask, value);
            }
        }

        public int FPS
        {
            get
            {
                return _FPS;
            }
            set
            {
                _FPS = value;
                material.SetFloat(TerrainBlockReference._FPS, (float)_FPS);
            }
        }
        protected Color BaseColor
        {
            set
            {
                _baseColor = value;
                material.SetColor(TerrainBlockReference._BaseColor, value);
            }
            get
            {
                return _baseColor;
            }
        }

        private Color AColor
        {
            set
            {
                _colorA = value;
                material.SetColor(TerrainBlockReference._ColorA, value);
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
                material.SetColor(TerrainBlockReference._ColorB, value);
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
                material.SetColor(TerrainBlockReference._ColorC, value);
            }
            get
            {
                return _colorC;
            }
        }

        private void Awake()
        {
            InitShader();
        }

        private void Start()
        {
            //InitShader();
        }

        public void ApplyColors(ScreenPalette.SpriteSubpalette spriteSubpalette)
        {
            //BaseColor = Color.white; // ScreenPalette.Instance.GetColor(spriteSubpalette.baseColorName);
            AColor = ScreenPalette.Instance.GetColor(spriteSubpalette.AColorName);
            BColor = ScreenPalette.Instance.GetColor(spriteSubpalette.BColorName);
            CColor = ScreenPalette.Instance.GetColor(spriteSubpalette.CColorName);
        }

        public void ApplyColors(ColorName colorA, ColorName colorB, ColorName colorC)
        {
            //BaseColor = Color.white; //ScreenPalette.Instance.GetColor(terrainSubpalette.baseColorName);
            AColor = ScreenPalette.Instance.GetColor(colorA);
            BColor = ScreenPalette.Instance.GetColor(colorB); 
            CColor = ScreenPalette.Instance.GetColor(colorC);
        }

        public void ApplyColors(int colorA, int colorB, int colorC)
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

        protected void SetFloat(string name, float value)
        {
            material.SetFloat(name, value);
        }

        private void InitShader()
        {
            //if (renderer == null)
            {
               // renderer = GetComponent<SpriteRenderer>();
            }
            material = renderer.material;
        }

        
    }
}
