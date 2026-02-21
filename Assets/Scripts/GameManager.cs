using UnityEngine;

public enum CottonDipType
{
    NONE = 0,
    HALDI = 1,
    LEAF = 2,
    SEED = 3
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    private CottonDipType currentDipType;

    public bool onCottonDipped = false;

    [Space(10)]
    [SerializeField] MeshRenderer skin;

    public void OnCottonPicked()
    {
        Debug.Log("OnCottonPicked");
    }

    public void OnCottonDropped()
    {
        Debug.Log("OnCottonPicked");
    }

    public void OnTermericTouched()
    {
        Debug.Log("OnTermericTouched");
        onCottonDipped = true;
        currentDipType = CottonDipType.HALDI;
    }

    public void OnSeedTouched()
    {
        Debug.Log("OnSeedTouched");
        onCottonDipped = true;
        currentDipType = CottonDipType.SEED;
    }

    public void OnLeafsTouched()
    {
        Debug.Log("OnLeafsTouched");
        onCottonDipped = true;
        currentDipType = CottonDipType.LEAF;
    }

    public void OnSkinTouched()
    {
        Debug.Log("OnSkinTouched");
        if (onCottonDipped)
        {
            Debug.Log("Cotton is wet and now applied on skin!");
            ChangeColor();
        }
        onCottonDipped = false;
    }

    public void ChangeColor()
    {
        Material mat = new Material(skin.material);
        skin.material = mat;
        mat.color = currentDipType == CottonDipType.HALDI ? Color.yellow :
          currentDipType == CottonDipType.SEED ? Color.black : Color.green;
    }

    public void OnHeadTouched()
    {
        Debug.Log("OnSkinTouched");
        if (onCottonDipped)
        {
            Debug.Log("Cotton is wet and now applied on skin!");
            Material mat = new Material(skin.material);
            skin.material = mat;
            mat.color = Color.yellow;
        }
        onCottonDipped = false;
    }

    [Space(10)] [SerializeField] GameObject skinRed;
    [SerializeField] GameObject skinWithEdges;
    public void OnSkinPlaced()
    {
        skinRed.SetActive(false);
        skinWithEdges.SetActive(false);
    }

    [Space(10)]
    [SerializeField] GameObject mesh1;
    [SerializeField] GameObject mesh2;
    public void Peelup()
    {
        Debug.Log("Peelup!");
        mesh1.SetActive(true);
        mesh2.SetActive(true);
    }
}
