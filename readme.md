# Justifications Design pattern

Hello Kevin here is the .md for all the justifications.

## Interfaces

For this project we chose to use interfaces such as:

### IHealth

This is a *"Kill Them All"* type game so almost everything must/can be killed.  
With this in mind a simple but effective interface needs to exist so we can keep track of every killable entities in the game.

This humble interface contains:


``` 
 > The base principle of a health amount is to lose some of it:
 abstract void TakeDamage(int amount);
``` 
``` 
> The base principle of a health amount is to *maybe* gain some of it:
abstract void RegainHealth(int amount);
``` 
``` 
> When the HP is get under or equal 0 *die*:
abstract void OnDeath();
```
```     
>  UI Function to update the unity base Slider:
abstract void UpdateSlider();
```
> **Note:** if the entities does not use a Slider; it  uses a return in this function &uarr;

### IStats

Here is the **Statistics** interface; Like the *Player*,  *Mobs* also can have stats, therefore we made an interface for them so they can have easely tweakable values.  
> **Note :** It's also now very easy to add statistics to other entities (like new enemies) in the game.

``` 
    int Str { get; protected set; }
    int Spe { get; protected set; }
    int Htl { get; protected set; }

    public virtual int CalculateStat(int baseStat, int stat)
    {
        return (int)(baseStat + baseStat * (float)stat / 100f);
    }
``` 
### IManager & SingletonManager

Even if **Singleton** managers are not **recommended**, they can be really useful for little or big projects.

So here lies the **interface**:  

``` 
    public abstract void Initialize();

    public abstract void ResetInstance();

    public abstract void Awake();

    public abstract void OnApplicationQuit();
``` 
> **Note :** The last 2 functions are here to ensure the user **always** uses the Unity base function.

And here is the **Mother Class**:
```
public class SingletonManager<T> : MonoBehaviour, IManager where T : MonoBehaviour
{
    public static T Instance { get; protected set;}
    public virtual void Initialize()
    {
        if(Instance is null)
        {
            Instance = this.GetComponent<T>();
            Debug.Log(name + " Set as " + GetType().Name);
        }
        else
        {
            Debug.LogWarning("Two (or more) " + GetType().Name + " are detected in scene -> Deleting " + name  +".");
            DestroyImmediate(gameObject);
            return;
        }
    }

    public void ResetInstance()
    {
        Instance = null;
        DestroyImmediate(gameObject);
        return;
    }

    private void Awake()
    {
        Initialize();
    }

    private void OnApplicationQuit()
    {
        ResetInstance();
    }
}
```
---
Like for IStats it's now very useful to create new Managers and to not have to worry about it for the rest of the project.

Even if the architecture happens to update these lines will not break in the future.

#### Here is an example of how it is implemented and how it doesn't flood the GameManager:

```
public class GameManager : SingletonManager<GameManager>
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
    }
}
```
> **Note :** *here*, the reset is only useful when *[Reloading Domain](https://docs.unity3d.com/6000.0/Documentation/Manual/domain-reloading.html "UNITY 6  Reload Domain API")* is off.

## State Machine

Here is the IState interface : 
```
    public bool HasStarted { get; set; }
    public bool IsInit { get; set; }
    public StateMachine _StateMachine { get; set; }

    public abstract void StateInit(StateMachine sm);
    public abstract void StateEnter();
    public abstract void StateUpdate();
    public abstract void StateExit();
```

Using an interface here is important because in a StateMachine you can find yourself with a lot of State; Having a normalized way to create them is Important

## Factory Pattern

We used a factory pattern to be able to easily instantiate different types of minions on the map.
Doing this allows to not modify the base code logic and only add new code if needed (for a new type of minion for example).

Here's an example of one of the minions factory/product:

### Minion with strength stat product:
```
    [SerializeField] private string mProductName = "MinionStr";
    
    public string ProductName
    {
        get => mProductName;
        set => mProductName = value;
    }

    private IStats minionStats;
    private int minionStrength;

    public void Initialize()
    {
        gameObject.name = mProductName;

        if (TryGetComponent<IStats>(out minionStats))
        {
            minionStrength = minionStats.CalculateStat(minionStrength, minionStats.Str);
        }
    }
```

### Minion with strength factory :
```
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
```

The minion products use a simple product interface:
```
    public interface IProduct
    {
        public string ProductName { get; set; }
    
        public void Initialize();
    }
```

In this case, all minion's "product" types have the same behaviour, as they just spawn in at the beginning of the game.
The only thing that changes is their stat attribution.
But if we had to continue the project, using this type of pattern would have been even more effective as we can easily change their behavior as well.

## Diagram 
Here is the diagram that explain the Main line of how the game should work: 
![How the Game work diagram](Justifications\Justification_Design_Patterns.png)
*How the game works diagram. -Made By Sacha Epry & Dan Cheype*