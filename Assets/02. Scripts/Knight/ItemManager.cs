using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
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
        // �κ��丮�� �ִ� ���
    }
}
