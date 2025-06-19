using UnityEngine;

public class Potion : MonoBehaviour, IItem
{
    private Inventory inventory;

    public enum PotionType { Gold, Hp, Mp }
    public PotionType potionType;

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
        Debug.Log($"{this.name}À» È¹µæÇÏ¿´½À´Ï´Ù.");

        inventory.AddItem(this);

        gameObject.SetActive(false);
    }
}
