using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public void Drop()
    {
        Debug.Log("���� ������.");
    }

    public void Grab()
    {
        Debug.Log("���� �ֿ��.");
    }

    public void Use()
    {
        Debug.Log("���� �߻��Ѵ�.");
    }
}
