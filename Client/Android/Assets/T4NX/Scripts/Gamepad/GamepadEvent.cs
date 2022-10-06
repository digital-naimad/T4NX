
namespace T4NX
{
    public enum GamepadEvent 
    {
        /// <summary>
        /// Direction UP button is pressed
        /// </summary>
        Up_Pressed,
        Up_Released,

        /// <summary>
        /// Direction DOWN button is pressed
        /// </summary>
        Down_Pressed,
        Down_Released,

        /// <summary>
        /// Direction LEFT button is pressed
        /// </summary>
        Left_Pressed,
        Left_Released,

        /// <summary>
        /// Direction RIGHT button is pressed
        /// </summary>
        Right_Pressed,
        Right_Released,

        /// <summary>
        /// Button SELECT is pressed now
        /// </summary>
        Select_Pressed,
        Select_Released,
        /// <summary>
        /// Button START is pressed now
        /// </summary>
        Start_Pressed,
        Start_Released,

        /// <summary>
        /// Action button B is pressed now
        /// </summary>
        B_Pressed,
        B_Released,
        /// <summary>
        /// Action button A is pressed now
        /// </summary>
        A_Pressed,
        A_Released,

        /// <summary>
        /// Mic_Detect
        /// TODO: implement detection and tracking of microphone input data
        /// </summary>
        Count //Mic_Detect

    }
    /*
   public struct GamepadEvent
   {
       public const int UpPressed = 0;
       public const int UpReleased = 1;

       public const int DownPressed = 2;
       public static int DownReleased = 3;

       public const int LeftPressed = 4;
       public const int LeftReleased = 5;

       public const int RightPressed = 6;
       public const int RightReleased = 7;

       public const int SelectPressed = 8;
       public const int SelectReleased = 9;

       public const int StartPressed = 10;
       public const int StartReleased = 11;

       public const int BPressed = 12;
       public const int BReleased = 13;

       public const int APressed = 14;
       public const int AReleased = 15;


   }
   */
}
