using System;
using Unity.Mathematics;
using UnityEngine;

public class MinionSpdFactory : Factory
{
    [SerializeField] private MinionSpd minionSpeedProductPrefab;

    private void OnEnable()
    {
        GetProduct();
    }

    public override IProduct GetProduct()
    {
        GameObject instance = Instantiate(minionSpeedProductPrefab.gameObject);
        MinionSpd newProductPrefab = instance.GetComponent<MinionSpd>();
        
        newProductPrefab.Initialize();

        return newProductPrefab;
    }
}
