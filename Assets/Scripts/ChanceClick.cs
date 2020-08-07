using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChanceClick : MonoBehaviour
{
    public TextMesh nameMesh;

    public SpriteRenderer backgroundRenderer;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            nameMesh.text = "Community\nChest";

            backgroundRenderer.color = Color.white;
        }
    }
}
