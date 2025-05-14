using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    private void Awake()
    {
        Initialize();
    }
}
