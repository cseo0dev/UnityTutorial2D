using UnityEngine;

// 클래스도 추상으로 해주어야 가능
public class Character : MonoBehaviour
{
    public IDropItem currentItem;
    [SerializeField] private Transform grabPos;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            currentItem.Use();
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            currentItem.Drop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDropItem>() != null)
        {
            IDropItem item = other.GetComponent<IDropItem>();
            
            item.Grab(grabPos); // 아이템 획득

            currentItem = item; // 아이템 장착
        }
    }
}
