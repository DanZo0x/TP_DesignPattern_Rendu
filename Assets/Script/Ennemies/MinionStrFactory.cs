using System;
using Unity.Mathematics;
using UnityEngine;

public class MinionStrFactory : Factory
{
    [SerializeField] private MinionStr minionStrengthProductPrefab;

    private void OnEnable()
    {
        GetProduct();
    }

    public override IProduct GetProduct()
    {
        GameObject instance = Instantiate(minionStrengthProductPrefab.gameObject);
        MinionStr newProductPrefab = instance.GetComponent<MinionStr>();
        
        newProductPrefab.Initialize();

        return newProductPrefab;
    }
}
