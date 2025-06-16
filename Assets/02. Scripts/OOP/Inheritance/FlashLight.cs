using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    //public GameObject lightObj;
    //public bool isLight;

    public void Drop()
    {
        Debug.Log("라이트를 버린다.");
    }

    public void Grab()
    {
        Debug.Log("라이트를 주운다.");
    }

    public void Use()
    {
        //isLight = !isLight;
        //lightObj.SetActive(isLight);

        Debug.Log("라이트를 켠다.");
    }
}