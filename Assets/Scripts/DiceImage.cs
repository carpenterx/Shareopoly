using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceImage : MonoBehaviour
{
    public List<Sprite> faceSprites;

    private Image image;

    public int Roll()
    {
        image = GetComponent<Image>();
        int dieIndex = Random.Range(0, faceSprites.Count);
        image.sprite = faceSprites[dieIndex];
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        transform.rotation = randomRotation;
        return dieIndex + 1;
    }
}
