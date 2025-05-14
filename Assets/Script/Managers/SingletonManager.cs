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
            Debug.Log(name + " Set as " + GetType().Name);
        }
        else
        {
            Debug.LogWarning("Two " + GetType().Name + " in scene Deleting " + name  +".");
            DestroyImmediate(gameObject);
            return;
        }
    }
}
