using UnityEngine;

public class watermelonseeds : MonoBehaviour
{
    public GameObject pasteStage1;
    public GameObject pasteStage2;
    public GameObject pasteStage3;
    public GameObject pasteStage4;
    //  public GameObject pasteStage4;
    private int hitCount = 0;
    private Vector3 originalScale;

    private bool canHit = true;   // prevents multiple instant triggers
    public float hitCooldown = 0.5f;

    void Start()
    {
        
     //   pasteStage1.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("seedStick") || !canHit)
            return;

        canHit = false;
        Invoke(nameof(ResetHit), hitCooldown);

        hitCount++;
        Debug.Log("Hit Count: " + hitCount);

        switch (hitCount)
        {
            case 1:
                pasteStage1.SetActive(false);
                pasteStage2.SetActive(true);
                break;
            case 2:
                pasteStage2.SetActive(false);
                pasteStage3.SetActive(true);
                break;
            case 3:
                pasteStage3.SetActive(false);
                pasteStage4.SetActive(true);
                break;
        }
    }

    void ResetHit()
    {
        canHit = true;
    }
}
