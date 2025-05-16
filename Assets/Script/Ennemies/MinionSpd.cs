using UnityEngine;

public class MinionSpd : MonoBehaviour, IProduct
{
    [SerializeField] private string mProductName = "MinionSpd";
    
    public string ProductName
    {
        get => mProductName;
        set => mProductName = value;
    }

    private IStats minionStats;
    private int minionSpeed;

    public void Initialize()
    {
        gameObject.name = mProductName;

        if (TryGetComponent<IStats>(out minionStats))
        {
            minionSpeed = minionStats.CalculateStat(minionSpeed, minionStats.Spe);
        }
    }
}
