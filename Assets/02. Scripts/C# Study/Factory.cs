// ���ŷο� �۾��� ���ʸ����� �ذ�
//public class Factory : MonoBehaviour
//{
//    public GameObject prefab;
//    public Monster monster;
//    public Orc orc;
//    public Goblin goblin;
//}

using UnityEngine;

public class Factory<T> : MonoBehaviour
{
    public T prefab;

    public Factory()
    {
        Debug.Log($"Factory�� {typeof(T)} Ÿ�� �Դϴ�.");
    }
}