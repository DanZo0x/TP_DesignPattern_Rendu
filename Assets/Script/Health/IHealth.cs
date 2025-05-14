using UnityEngine;
using UnityEngine.UI;

public interface IHealth
{
    int _currentHealth { get; protected set; }
    int _maxHealth { get; protected set; }

    Slider slider { get; set; }

    abstract void TakeDamage(int amount);
    abstract void RegainHealth(int amount);
    abstract void UpdateSlider();
    abstract void OnDeath();

}
