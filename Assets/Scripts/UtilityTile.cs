using UnityEngine;
using UnityEngine.EventSystems;

public class UtilityTile : MonoBehaviour
{
    public UtilityScriptableObject tileData;
    
    public TextMesh nameMesh;
    public TextMesh costMesh;

    public SpriteRenderer backgroundRenderer;

    private void Start()
    {
        if(tileData)
        {
            nameMesh.text = tileData.tileText;
            costMesh.text = tileData.costText;
        }
    }

    /*private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            nameMesh.text = "King Cross\nStation";
            costMesh.text = "$150";

            backgroundRenderer.color = Color.white;
        }
    }*/
}
