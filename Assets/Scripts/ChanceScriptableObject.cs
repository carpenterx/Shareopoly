using UnityEngine;

[CreateAssetMenu(fileName = "ChanceTileData", menuName = "ScriptableObjects/ChanceScriptableObject", order = 3)]
public class ChanceScriptableObject : ScriptableObject
{
    [TextArea]
    public string tileText;
}
