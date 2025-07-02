using UnityEngine;

public interface IItemObject
{
    ItemManager Inventory { get; set; }
    GameObject Obj { get; set; }
    Sprite Icon { get; set; }
    string ItemName { get; set; }

    void Get();
    void Use();
}
