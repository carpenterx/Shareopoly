using System.Collections.Generic;
using UnityEngine;

public class DiceSprite : MonoBehaviour
{
    public List<Sprite> faceSprites;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        Roll();
    }

    private void OnMouseDown()
    {
        Roll();
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
