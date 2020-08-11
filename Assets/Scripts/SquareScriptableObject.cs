using UnityEngine;

[CreateAssetMenu(fileName = "SquareTileData", menuName = "ScriptableObjects/SquareScriptableObject", order = 4)]
public class SquareScriptableObject : ScriptableObject
{
    [TextArea]
    public string tileText;
    //public int rotationMultiplyer = 0;
}
