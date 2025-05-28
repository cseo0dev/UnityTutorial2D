using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    // �����
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
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