using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combination", menuName = "ScriptableObjects/CombinationScriptableObject", order = 5)]
public class CombinationScriptableObject : ScriptableObject
{
    public string combinationName;
    public List<Sprite> diceSprites;
}
