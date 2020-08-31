using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    public CombinationScriptableObject combinationData;

    public TextMesh nameMesh;
    public List<SpriteRenderer> combinationDice;

    void Start()
    {
        if (combinationData)
        {
            nameMesh.text = combinationData.combinationName;
            for (int i = 0; i < combinationDice.Count; i++)
            {
                combinationDice[i].sprite = combinationData.diceSprites[i];
            }
        }
    }
}
