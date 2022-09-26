namespace T4NX
{
    public class TankController : CustomSprite
    {
        //ScreenPalette.SpriteSubpalette spriteSubpalette;
        private string _tankerName;

        
       
        /// <summary>
        /// 
        /// </summary>
        public string TankerName { get { return _tankerName; } }
        

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InitWithData(string tankerName, ColorName colorA, ColorName colorB, ColorName colorC)
        {
            _tankerName = tankerName;

            ApplyColors(colorA, colorB, colorC);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="tankerColor"></param>
        public void ApplyTankerColors(TankerColor tankerColor)
        {

        }
       
    }
}
