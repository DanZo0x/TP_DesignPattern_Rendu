using UnityEngine;

public interface IManager
{
    public static IManager Instance;
    
    public virtual void SetInstance(object obj)
    {
        if(Instance == null) Instance = this;
        else GameObject.DestroyImmediate(this as Object as GameObject);
    }
}
