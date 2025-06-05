using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    public GameObject fadeUI;

    // �����
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // ���� ���� UI
            fadeUI.SetActive(true);

            Debug.Log("Game Over");
        }
    }

    // ��ü
    // isTrigger = false�� ��� ȣ��
    //void OnCollisionEnter(Collision other)
    //{
    //    Debug.Log($"{this.gameObject.name} Collision Enter");
    //}

    //// isTrigger = true�� ��� ȣ��
    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log($"{this.gameObject.name} Trigger Enter");

    //}
}