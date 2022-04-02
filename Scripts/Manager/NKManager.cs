using UnityEngine;

namespace NK.RuntimeSetSystem
{
    public abstract class NKManager : MonoBehaviour
    {
        public NKManagerRuntimeSet RuntimeSet;

        protected virtual void OnEnable()
        {
            if (RuntimeSet == null)
                RuntimeSet = NKRuntimeSet.GetRuntimeSet<NKManagerRuntimeSet>();
            RuntimeSet?.Add(this);
        }

        protected virtual void OnDisable()
        {
            RuntimeSet?.Remove(this);
        }
    }
}