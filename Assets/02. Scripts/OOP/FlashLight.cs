using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject lightObj;

    public void Drop()
    {
        transform.SetParent(null);
        transform.position = Vector3.zero;

        Debug.Log("라이트를 버린다.");
    }

    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        Debug.Log("라이트를 주운다.");
    }

    public void Use()
    {
        lightObj.SetActive(!lightObj.activeSelf); // 반대로 작동되게
        Debug.Log("라이트를 켠다.");
    }
}