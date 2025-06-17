using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject lightObj;

    public void Drop()
    {
        transform.SetParent(null);
        transform.position = Vector3.zero;

        Debug.Log("����Ʈ�� ������.");
    }

    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        Debug.Log("����Ʈ�� �ֿ��.");
    }

    public void Use()
    {
        lightObj.SetActive(!lightObj.activeSelf); // �ݴ�� �۵��ǰ�
        Debug.Log("����Ʈ�� �Ҵ�.");
    }
}