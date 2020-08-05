using UnityEngine;

public class UtilityClick : MonoBehaviour
{
    public TextMesh nameMesh;
    public TextMesh costMesh;

    public SpriteRenderer backgroundRenderer;

    private void OnMouseDown()
    {
        nameMesh.text = "King Cross\nStation";
        costMesh.text = "$150";

        backgroundRenderer.color = Color.white;
    }
}
