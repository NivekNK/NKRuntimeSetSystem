# NK RuntimeSet System

To use the **NK RuntimeSet System**, you need to clone the repository to the "Assets/Plugins/NKTools" folder path and create the "Assets/Resources/RuntimeSets" folder, there you need to create the RuntimeSet.

![NKRuntimeSetSystem](https://i.imgur.com/zdbYUQr.png "NKMangerRuntimeSet")

This RuntimeSet system allows you to define classes of type "Singleton", which you can find and use in other classes. It comes with an example of the Manager class type.

## NKManager Class
```csharp
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
```
What you can do now is inherit the class NKManager and use search for the created class in the "RuntimeSet".

```csharp
using NK.RuntimeSetSystem;

public class ClassA : NKManager
{
    public string Name = "ClassA";
}
```

```csharp
using NK.RuntimeSetSystem;

public class ClassB : MonoBehaviour
{
    private void Start()
    {
        var runtimeSet = NKRuntimeSet.GetRuntimeSet<NKManagerRuntimeSet>();

        if (runtimeSet.GetTypeOfRuntimeSet(out ClassA classA))
            Debug.Log(classA.Name);
    }
}
```