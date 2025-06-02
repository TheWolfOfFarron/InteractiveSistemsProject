using UnityEngine;

public abstract class Singeleton<T> : MonoBehaviour where T : MonoBehaviour
{

    public static T Instance {  get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this as T;
    }

    protected virtual void onApplicationQuit()
    {
        Instance=null;
        Destroy(gameObject);
    }
}


public abstract class PersistentSingeleton<T>: Singeleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

}
