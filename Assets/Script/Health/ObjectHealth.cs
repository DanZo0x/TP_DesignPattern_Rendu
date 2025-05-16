using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
//[RequireComponent(typeof(IStats))]
public class ObjectHealth : MonoBehaviour, IHealth
{
    [ShowNonSerializedField] private int currentHealth;
    int IHealth.currentHealth { get => currentHealth; set => currentHealth = value; }

    [Header("Base Stats")]
    [SerializeField] private int maxHealth = 100;
    int IHealth.maxHealth { get => maxHealth; set => maxHealth = value; }



    IStats stats;
    int maxHealthWithStat;


    [Header("UI")]
    [SerializeField] Slider uiSlider;
    Slider IHealth.slider { get; set; }
    
    private void Awake()
    {
        if (TryGetComponent<IStats>(out stats)) maxHealthWithStat = stats.CalculateStat(maxHealth, stats.Htl);
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
        //Tests Obviously
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
        }
    }
}
