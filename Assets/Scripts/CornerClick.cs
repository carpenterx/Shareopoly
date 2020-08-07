using UnityEngine;
using UnityEngine.EventSystems;

public class CornerClick : MonoBehaviour
{
    public GameObject textHolder;
    public TextMesh textMesh;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            float currentRotation = textHolder.transform.rotation.eulerAngles.z;
            Quaternion rotation = Quaternion.Euler(0, 0, currentRotation + 90);
            textHolder.transform.rotation = rotation;
            textMesh.text = "PASS GO\nCollect $200";
        }
    }
}
