using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public List<IItem> items = new List<GameObject>(); // �������̽��� �ν����Ϳ� �� ����
    public List<GameObject> items = new List<GameObject>();

    public void AddItem(IItem item)
    {
        items.Add(item.Obj);
    }
}
