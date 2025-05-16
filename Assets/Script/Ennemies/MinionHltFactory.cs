using System;
using Unity.Mathematics;
using UnityEngine;

public class MinionHltFactory : Factory
{
    [SerializeField] private MinionHlt minionHealthProductPrefab;

    private void OnEnable()
    {
        GetProduct();
    }

    public override IProduct GetProduct()
    {
        GameObject instance = Instantiate(minionHealthProductPrefab.gameObject);
        MinionHlt newProductPrefab = instance.GetComponent<MinionHlt>();
        
        newProductPrefab.Initialize();

        return newProductPrefab;
    }
}
