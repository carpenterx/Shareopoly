using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceClick : MonoBehaviour
{
    public TextMesh nameMesh;

    public SpriteRenderer backgroundRenderer;

    private void OnMouseDown()
    {
        nameMesh.text = "Community\nChest";

        backgroundRenderer.color = Color.white;
    }
}
