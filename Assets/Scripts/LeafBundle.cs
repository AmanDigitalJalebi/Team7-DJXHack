using UnityEngine;

public class LeafBundle : MonoBehaviour
{
    public GameObject leavesObject;
    public GameObject pasteStage1;
    public GameObject pasteStage2;
    public GameObject pasteStage3;
    private int hitCount = 0;
    private Vector3 originalScale;

    private bool canHit = true;   // prevents multiple instant triggers
    public float hitCooldown = 0.5f;

    void Start()
    {
        originalScale = leavesObject.transform.localScale;
        pasteStage1.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Stick") || !canHit)
            return;

        canHit = false;
        Invoke(nameof(ResetHit), hitCooldown);

        hitCount++;
        Debug.Log("Hit Count: " + hitCount);

        switch (hitCount)
        {
            case 1:
                leavesObject.transform.localScale = originalScale * 0.7f;
                pasteStage1.SetActive(true);
                break;

            case 2:
                leavesObject.transform.localScale = originalScale * 0.5f;
                pasteStage1.SetActive(false);
                pasteStage2.SetActive(true);
                break;

            case 3:
                leavesObject.SetActive(false);
                pasteStage2.SetActive(false);
                pasteStage3.SetActive(true);
                break;

            
        }
    }
    
    void ResetHit()
    {
        canHit = true;
    }

}
