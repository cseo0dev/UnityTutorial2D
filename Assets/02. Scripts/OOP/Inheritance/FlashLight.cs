using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    //public GameObject lightObj;
    //public bool isLight;

    public void Drop()
    {
        Debug.Log("����Ʈ�� ������.");
    }

    public void Grab()
    {
        Debug.Log("����Ʈ�� �ֿ��.");
    }

    public void Use()
    {
        //isLight = !isLight;
        //lightObj.SetActive(isLight);

        Debug.Log("����Ʈ�� �Ҵ�.");
    }
}