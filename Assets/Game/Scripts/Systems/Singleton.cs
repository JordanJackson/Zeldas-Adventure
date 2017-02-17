using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Static reference to instance
    protected static T instance;

    protected bool initialized;

    /// <summary>
    /// 
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name, typeof(T));
                    instance = go.GetComponent<T>();
                }
            }

            return instance;
        }
    }

    /// <summary>
    /// Returns true if this has a reference to a valid instance.
    /// </summary>
    /// <returns></returns>
    public static bool IsValidSingleton()
    {
        return instance != null;
    }
}
