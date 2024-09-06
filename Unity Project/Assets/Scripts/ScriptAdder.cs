using UnityEngine;

/// <summary>
/// used to add a itself to the gameObject which contains <see cref="T"/> on <see cref="Awake"/>
/// </summary>
/// <typeparam name="T">the component that is on the gameObject an instance type is added to</typeparam>
public abstract class ScriptAdder<T> : MonoBehaviour where T : Component //make sure the type parameter T is derived from a Component
{
    protected virtual void Awake()
    {
        if (GetComponent<T>() != null)
            return;

        //find the component and add the  to it
        Component[] components = FindObjectsOfType<T>(); //find the object of type T
        foreach (Component component in components)
        {
            component.gameObject.AddComponent(GetType()); //GetType() gets the type of the instance
        }
        Destroy(this); //remove the instance from the current script because we don't belong here >:3
    }
}
