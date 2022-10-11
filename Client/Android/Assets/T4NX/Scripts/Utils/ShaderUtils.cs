namespace T4NX
{
    public class ShaderUtils : MonoSingleton<ShaderUtils>
    {
        #region MonoBehaviour callbacks

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Logic Utillities
        /// <summary>
        /// Converts boolean value into ShaderGraph bool parameter which is just integer value 1 or 0 
        /// </summary>
        /// <param name="conditionResult">eg TankDirection == Direction.North</param>
        /// <returns></returns>
        public static int ShaderBool(bool conditionResult)
        {
            return conditionResult ? 1 : 0;
        }
        #endregion
    }
}
