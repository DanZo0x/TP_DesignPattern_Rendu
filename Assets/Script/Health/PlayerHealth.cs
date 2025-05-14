using NaughtyAttributes;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [ShowNonSerializedField] private int currentHealth = 100;
    int IHealth._currentHealth { get => currentHealth; set => currentHealth = value; }

    [SerializeField] private int maxHealth = 100;
    int IHealth._maxHealth { get => maxHealth; set => maxHealth = value; }



    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            OnDeath();
        }
    }

    public void RegainHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    public void OnDeath()
    {
        Debug.Log(name = " Died.");
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            RegainHealth(10);
        }
    }
}
