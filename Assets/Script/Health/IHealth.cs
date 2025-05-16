using UnityEngine;
using UnityEngine.UI;

public interface IHealth
{
    int currentHealth { get; protected set; }
    int maxHealth { get; protected set; }

    Slider slider { get; set; }

    abstract void TakeDamage(int amount);
    abstract void RegainHealth(int amount);
    abstract void UpdateSlider();
    abstract void OnDeath();

}
