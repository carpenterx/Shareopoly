using UnityEngine;

[CreateAssetMenu(fileName = "UtilityTileData", menuName = "ScriptableObjects/UtilityScriptableObject", order = 2)]
public class UtilityScriptableObject : ScriptableObject
{
    //public Color propertyColor;
    [TextArea]
    public string tileText;
    public string costText;
}
