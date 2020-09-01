using System.Collections.Generic;
using UnityEngine;

public class DiceSprite : MonoBehaviour
{
    public List<Sprite> faceSprites;

    public SpriteRenderer spriteRenderer;

    private static string DROP_ZONE_TAG = "DropZone";

    private bool isDraggable = true;
    private bool isBeingDragged = false;
    private bool isInsideDropZone = false;

    private void Start()
    {
        Roll();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == DROP_ZONE_TAG)
        {
            isInsideDropZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == DROP_ZONE_TAG)
        {
            isInsideDropZone = false;
        }
    }

    private void OnMouseDown()
    {
        //Roll();
        isBeingDragged = true;
    }

    private void OnMouseUp()
    {
        isBeingDragged = false;
        if(isInsideDropZone)
        {
            isDraggable = false;
        }
    }

    private void OnMouseDrag()
    {
        if (isDraggable && isBeingDragged)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 9;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = worldPosition;
        }
    }

    public int Roll()
    {
        int dieIndex = Random.Range(0, faceSprites.Count);
        spriteRenderer.sprite = faceSprites[dieIndex];
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        transform.rotation = randomRotation;
        return dieIndex + 1;
    }
}
