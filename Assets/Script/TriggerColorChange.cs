using UnityEngine;

public class TriggerColorChange : MonoBehaviour
{
    private Renderer objRenderer;
    

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("haldi"))
        {
            objRenderer.material.color = Color.yellow;
        }
        else if(other.CompareTag("leaves"))
        {
            objRenderer.material.color = Color.green;
        }
        else if (other.CompareTag("seed"))
        {
            objRenderer.material.color = Color.black;
        }
    }
}
