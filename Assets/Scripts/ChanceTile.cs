using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChanceTile : MonoBehaviour
{
    public ChanceScriptableObject tileData;

    public TextMesh nameMesh;

    public SpriteRenderer backgroundRenderer;

    private void Start()
    {
        if(tileData)
        {
            nameMesh.text = tileData.tileText;
        }
    }

    /*private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            nameMesh.text = "Community\nChest";

            backgroundRenderer.color = Color.white;
        }
    }*/
}
