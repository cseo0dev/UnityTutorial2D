using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject inventoryUI;
    public Button inventoryButton;

    [SerializeField] private GameObject[] items;

    [SerializeField] private Transform slotGroup;
    public Slot[] slots;

    void Start()
    {
        // 자신과 자식 중에서 Slot Component가 있는 대상을 모두 가져오는 기능
        slots = slotGroup.GetComponentsInChildren<Slot>(true); // true -> 비활성화 되어있는 것도 갖고옴

        // 인벤토리 버튼을 눌렀을 때 OnInventory 함수 실행
        inventoryButton.onClick.AddListener(OnInventory);
    }

    public void OnInventory()
    {
        // GameObject.activeSelf = 현재 Active 상태
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void DropItem(Vector3 dropPos)
    {
        var randomX = Random.Range(0, items.Length);

        GameObject item = Instantiate(items[randomX], dropPos, Quaternion.identity);

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);

        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {
        // 빈 슬롯을 찾아서 AddItem 수행
        foreach (var slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.AddItem(item);
                break; // 브레이크를 해주지 않으면 모든 빈슬롯에 다 넣어버림
            }
        }
    }
}
