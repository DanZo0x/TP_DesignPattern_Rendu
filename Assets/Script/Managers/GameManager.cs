using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    [SerializeField] private Transform player;
    public Transform GetPlayer { get => player;}

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
    }
}
