using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public void Drop()
    {
        Debug.Log("총을 버린다.");
    }

    public void Grab()
    {
        Debug.Log("총을 주운다.");
    }

    public void Use()
    {
        Debug.Log("총을 발사한다.");
    }
}
