using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MyUnityLibrary
{
    public class CMonoBehaviour : MonoBehaviour
    {
        public virtual void Init()
        {

        }
    }

    public class SingletonMonoBehaviour<T> where T : CMonoBehaviour
    {
        protected static T instance;

        /**
          Returns the instance of this singleton.
       */
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)GameObject.FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        Debug.LogError("An instance of " + typeof(T) +
                            " is needed in the scene, but there is none.");
                    }

                    instance.Init();
                }
                return instance;
            }
        }

        public static void DestroyExtraObjects(GameObject obj)
        {
            if (obj != Instance.gameObject)
            {
                GameObject.Destroy(obj);
            }
        }

        public static bool DestroyExtraObjects(MonoBehaviour scriptObj)
        {
            bool shouldDestroy = false;
            if (scriptObj != Instance)
            {
                GameObject.Destroy(scriptObj.gameObject);
                shouldDestroy = true;
            }

            return shouldDestroy;
        }
    }

    public class Singleton<T> where T : class
    {
        protected static T instance;

        /**
          Returns the instance of this singleton.
       */
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = System.Activator.CreateInstance(typeof(T)) as T;
                    if (null == instance)
                    {
                        Debug.LogAssertion("Singleton object init failed: " + typeof(T).Name);
                    }
                }

                return instance;
            }
        }

        public static void Destroy()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
    }

    public class DontDestoryOnLoadBehaviour<T> where T : MonoBehaviour
    {
        public static void Check(T t, ref T instance)
        {
            Debug.LogFormat("this {0}, instance {1}", t, instance);

            if (null == instance)
            {
                instance = t;
            }
            else if (t != instance)
            {
                GameObject.Destroy(t.gameObject);
                return;
            }
            MonoBehaviour.DontDestroyOnLoad(t.gameObject);
        }
    }
}
