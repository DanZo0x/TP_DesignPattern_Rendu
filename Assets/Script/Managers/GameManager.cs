using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
    }
}
