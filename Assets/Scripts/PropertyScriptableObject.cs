using UnityEngine;

[CreateAssetMenu(fileName = "PropertyTileData", menuName = "ScriptableObjects/PropertyScriptableObject", order = 1)]
public class PropertyScriptableObject : ScriptableObject
{
    public Color propertyColor;
    [TextArea]
    public string tileText;
    public string costText;
}
