using UnityEngine;
using UnityEngine.EventSystems;

public class PropertyClick : MonoBehaviour
{
    public TextMesh nameMesh;
    public TextMesh costMesh;

    public SpriteRenderer topRenderer;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            nameMesh.text = "Park Place";
            costMesh.text = "$200";

            topRenderer.color = Color.blue;
        }
            
    }

}
