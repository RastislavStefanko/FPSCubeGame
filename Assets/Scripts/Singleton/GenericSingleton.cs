using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    /// <summary>
    /// generic instance of singleton
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                instance = obj.AddComponent<T>();
            }
            return instance;
        }
    }

    /// <summary>
    /// assign instance to variable and destroy copies
    /// </summary>
    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
