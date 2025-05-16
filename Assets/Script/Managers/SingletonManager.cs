using Unity.VisualScripting;
using UnityEngine;

public class SingletonManager<T> : MonoBehaviour, IManager where T : MonoBehaviour
{
    public static T Instance { get; protected set;}
    public virtual void Initialize()
    {
        if(Instance is null)
        {
            Instance = this.GetComponent<T>();
            Debug.Log("Object : " + name + " Set as " + GetType().Name);
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

    public virtual void Awake()
    {
        Initialize();
    }

    public virtual void OnApplicationQuit()
    {
        ResetInstance();
    }
}
