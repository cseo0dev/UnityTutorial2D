using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public static int coinCount = 0;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;

        transform.LookAt(transform.position + dir);
    }
}
