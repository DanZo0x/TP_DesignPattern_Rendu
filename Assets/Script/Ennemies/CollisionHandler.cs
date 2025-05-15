using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private IHealth Health;

    private void Awake()
    {
        Health = GetComponent<IHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("AttackHitbox"))
        {
            return;
        }
        
        Health.TakeDamage(10);
    }
}
