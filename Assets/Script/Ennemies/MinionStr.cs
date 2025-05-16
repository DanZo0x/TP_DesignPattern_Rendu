using UnityEngine;

public class MinionStr : MonoBehaviour, IProduct
{
    [SerializeField] private string mProductName = "MinionStr";
    
    public string ProductName
    {
        get => mProductName;
        set => mProductName = value;
    }

    private IStats minionStats;
    private int minionStrength;

    public void Initialize()
    {
        gameObject.name = mProductName;

        if (TryGetComponent<IStats>(out minionStats))
        {
            minionStrength = minionStats.CalculateStat(minionStrength, minionStats.Str);
        }
    }
}
