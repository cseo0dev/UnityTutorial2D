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
        // �ڽŰ� �ڽ� �߿��� Slot Component�� �ִ� ����� ��� �������� ���
        slots = slotGroup.GetComponentsInChildren<Slot>(true); // true -> ��Ȱ��ȭ �Ǿ��ִ� �͵� �����

        // �κ��丮 ��ư�� ������ �� OnInventory �Լ� ����
        inventoryButton.onClick.AddListener(OnInventory);
    }

    public void OnInventory()
    {
        // GameObject.activeSelf = ���� Active ����
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
        // �� ������ ã�Ƽ� AddItem ����
        foreach (var slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.AddItem(item);
                break; // �극��ũ�� ������ ������ ��� �󽽷Կ� �� �־����
            }
        }
    }
}
