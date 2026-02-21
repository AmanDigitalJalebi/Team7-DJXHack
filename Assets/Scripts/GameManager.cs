using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }



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
    }

    public void OnSkinTouched()
    {
        Debug.Log("OnSkinTouched");

        if (onCottonDipped)
        {
            Debug.Log("Cotton is wet and now applied on skin!");
            Material mat = new Material(skin.material);
            skin.material = mat;
            mat.color = Color.yellow;
        }
    }

}
