using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [ShowNonSerializedField] private int currentHealth = 100;
    int IHealth._currentHealth { get => currentHealth; set => currentHealth = value; }

    [SerializeField] private int maxHealth = 100;
    int IHealth._maxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField] Slider uiSlider;
    Slider IHealth.slider { get; set; }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath();
        }
        UpdateSlider();
    }

    public void RegainHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateSlider();
    }

    public void OnDeath()
    {
        Debug.Log(name + " Died.");
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

    public void UpdateSlider()
    {
        if (uiSlider)
        {
            float value = (float)currentHealth / (float)maxHealth;
            uiSlider.value = value;
            print(value);
        }
    }
}
