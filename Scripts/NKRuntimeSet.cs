using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace NK.RuntimeSetSystem
{
    public abstract class NKRuntimeSet : ScriptableObject
    {
        /// <summary>
        /// Returns the first encountered RuntimeSet of the specified type in "Resources/RuntimeSets" folder or null if none is found.
        /// </summary>
        /// <typeparam name="TRuntimeSet"></typeparam>
        /// <returns></returns>
        public static TRuntimeSet GetRuntimeSet<TRuntimeSet>() where TRuntimeSet : NKRuntimeSet
        {
            return Resources.LoadAll<TRuntimeSet>("RuntimeSets").FirstOrDefault();
        }
    }

    public abstract class NKRuntimeSet<T> : NKRuntimeSet where T : MonoBehaviour
    {
        public SerializedDictionary<string, T> Sets = new SerializedDictionary<string, T>();

        public void Add(T t)
        {
            string key = t.GetType().Name;
            if (!Sets.ContainsKey(key))
                Sets.Add(key, t);
        }

        public bool Remove(T t)
        {
            return Sets.Remove(t.GetType().Name);
        }

        /// <summary>
        /// Search for a MonoBehaviour of type "TType" in the RuntimeSet.
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="set"></param>
        /// <returns></returns>
        public bool GetTypeOfRuntimeSet<TType>(out TType set) where TType : T
        {
            bool retVal = Sets.TryGetValue(typeof(TType).Name, out T value);
            set = (TType)value;
            return retVal;
        }
    }
}