using UnityEngine;

public class TermericBowlCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter TermericBowlCollider");
        if(other.gameObject.tag == "Cotton")
        {
            Debug.Log("OnTriggerEnter Cotton");
            GameManager.Instance.onCottonDipped = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
