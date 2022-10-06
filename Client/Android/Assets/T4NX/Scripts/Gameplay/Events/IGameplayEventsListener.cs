
namespace T4NX
{
    public interface IGameplayEventsListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void OnPlayerTankSpawn(short data);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void OnPlayerTankMove(short data);
    }
}
