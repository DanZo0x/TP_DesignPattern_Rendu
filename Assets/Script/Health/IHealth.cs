using UnityEngine;

public interface IHealth
{
    int _currentHealth { get; protected set; }
    int _maxHealth { get; protected set; }

    abstract void TakeDamage(int amount);
     abstract void RegainHealth(int amount);
     abstract void OnDeath();

}
