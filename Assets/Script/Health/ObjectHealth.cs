using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(IStats))]
public class ObjectHealth : MonoBehaviour, IHealth
{
    [ShowNonSerializedField] private int currentHealth;
    int IHealth._currentHealth { get => currentHealth; set => currentHealth = value; }

    [Header("Base Stats")]
    [SerializeField] private int maxHealth = 100;
    int IHealth._maxHealth { get => maxHealth; set => maxHealth = value; }



    IStats stats;
    int maxHealthWithStat;


    [Header("UI")]
    [SerializeField] Slider uiSlider;
    Slider IHealth.slider { get; set; }
    
    private void Awake()
    {
        stats = GetComponent<IStats>();
        if (stats != null) maxHealthWithStat = stats.calculateStat(maxHealth, stats.Htl);
        else maxHealthWithStat = maxHealth;

        currentHealth = maxHealthWithStat;
    }

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
        if (currentHealth > maxHealthWithStat) currentHealth = maxHealthWithStat;
        UpdateSlider();
    }

    public void OnDeath()
    {
        Debug.Log(name + " Died.");
        Destroy(this.gameObject);
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
            float value = (float)currentHealth / (float)maxHealthWithStat;
            uiSlider.value = value;
            print(value);
        }
    }
}
