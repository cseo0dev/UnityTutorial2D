using UnityEngine;

public class CoinMonster : MonoBehaviour, IItem
{
    private Inventory inventory;

    public enum CoinType { Gold, Green, Box }
    public CoinType coinType;

    public float price;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();

        Obj = gameObject;
    }

    void OnMouseDown()
    {
        Get();
    }

    public GameObject Obj { get; set; }

    public void Get()
    {
        Debug.Log($"{this.name}�� ȹ���Ͽ����ϴ�.");

        inventory.AddItem(this);

        gameObject.SetActive(false);
    }
}
