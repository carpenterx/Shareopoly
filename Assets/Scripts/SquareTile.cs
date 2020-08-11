using UnityEngine;
using UnityEngine.EventSystems;

public class SquareTile : MonoBehaviour
{
    public PropertyScriptableObject tileData;
    public GameObject textHolder;
    public TextMesh textMesh;

    private void Start()
    {
        if(tileData)
        {
            textMesh.text = tileData.tileText;
        }
    }

    /*private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            float currentRotation = textHolder.transform.rotation.eulerAngles.z;
            Quaternion rotation = Quaternion.Euler(0, 0, currentRotation + 90);
            textHolder.transform.rotation = rotation;
            textMesh.text = "PASS GO\nCollect $200";
        }
    }*/
}
