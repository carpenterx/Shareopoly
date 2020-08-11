using UnityEngine;
using UnityEngine.EventSystems;

public class PropertyTile : MonoBehaviour
{
    public PropertyScriptableObject tileData;

    public TextMesh nameMesh;
    public TextMesh costMesh;

    public SpriteRenderer topRenderer;

    private void Start()
    {
        if(tileData)
        {
            topRenderer.color = tileData.propertyColor;

            nameMesh.text = tileData.tileText;
            costMesh.text = tileData.costText;
        }
    }

    /*private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            nameMesh.text = "Park Place";
            costMesh.text = "$200";

            topRenderer.color = Color.blue;
        }
            
    }*/
}
