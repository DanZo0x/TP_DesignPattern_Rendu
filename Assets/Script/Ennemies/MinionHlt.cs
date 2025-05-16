using UnityEngine;

public class MinionHlt : MonoBehaviour, IProduct
{
    [SerializeField] private string mProductName = "MinionHlt";
    
    public string ProductName
    {
        get => mProductName;
        set => mProductName = value;
    }

    private IStats minionStats;
    private int minionHealth;

    public void Initialize()
    {
        gameObject.name = mProductName;

        if (TryGetComponent<IStats>(out minionStats))
        {
            minionHealth = minionStats.CalculateStat(minionHealth, minionStats.Htl);
        }
    }
}
