using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Tool")]
public class ToolClass : ItemClass
{
    [Header("Tool")] // data specific to tool class
    public ToolType toolType;    
    
    public enum ToolType
    {
        sword
    }

    public override ToolClass GetTool() { return this; }

}
