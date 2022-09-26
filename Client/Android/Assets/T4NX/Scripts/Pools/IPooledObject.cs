/// <summary>
/// Interface using by ObjectPooler and implementing in Enemy controller class
/// </summary>
namespace T4NX
{
    public interface IPooledObject
    {
        void OnSpawn();
    }
}