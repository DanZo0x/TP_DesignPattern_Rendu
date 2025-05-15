using UnityEngine;

public interface IManager
{
    public abstract void Initialize();
    public abstract void ResetInstance();
    public abstract void Awake();
    public abstract void OnApplicationQuit();

}
