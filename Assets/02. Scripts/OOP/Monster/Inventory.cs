using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public List<IItem> items = new List<GameObject>(); // 인터페이스라 인스펙터에 안 보임
    public List<GameObject> items = new List<GameObject>();

    public void AddItem(IItem item)
    {
        items.Add(item.Obj);
    }
}
