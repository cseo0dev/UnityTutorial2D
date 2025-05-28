using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    // 고양이
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
        }
    }

    // 구체
    // isTrigger = false일 경우 호출
    //void OnCollisionEnter(Collision other)
    //{
    //    Debug.Log($"{this.gameObject.name} Collision Enter");
    //}

    //// isTrigger = true일 경우 호출
    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log($"{this.gameObject.name} Trigger Enter");

    //}
}