namespace T4NX
{
    public class TankController : CustomSprite
    {
        //ScreenPalette.SpriteSubpalette spriteSubpalette;
        private string _tankistName;

        
       
        /// <summary>
        /// 
        /// </summary>
        public string TankistName { get { return _tankistName; } }
        

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InitWithData(string tankistName, ColorName colorA, ColorName colorB, ColorName colorC)
        {
            _tankistName = tankistName;

            ApplyColors(colorA, colorB, colorC);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="tankistColor"></param>
        public void ApplyTankerColors(TankistColor tankerColor)
        {

        }
       
    }
}
