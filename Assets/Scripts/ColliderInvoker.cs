using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ColliderInvoker : MonoBehaviour
{
    public string tagName;
    public UnityEvent OnTriggerEnteredEvent;
    public UnityEvent OnTriggerExitEvent;


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == tagName)
        {
            OnTriggerEnteredEvent?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == tagName)
        {
            OnTriggerExitEvent?.Invoke();
        }
    }
}
