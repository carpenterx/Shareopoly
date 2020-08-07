using UnityEngine;
using UnityEngine.EventSystems;

public class UtilityClick : MonoBehaviour
{
    public TextMesh nameMesh;
    public TextMesh costMesh;

    public SpriteRenderer backgroundRenderer;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            nameMesh.text = "King Cross\nStation";
            costMesh.text = "$150";

            backgroundRenderer.color = Color.white;
        }
    }
}
