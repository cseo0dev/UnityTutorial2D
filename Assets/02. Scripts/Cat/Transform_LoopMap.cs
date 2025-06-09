using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 0.3f;
    public float returnPosX = 15f;
    public float randomPosY;

    void Start()
    {
        randomPosY = Random.Range(-4f, -0.5f);
        transform.position = new Vector3(transform.position.x, randomPosY, 0.1f);
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        if (transform.position.x <= -returnPosX)
        {
            // Pipe�� ������ ���̿� ��Ÿ������ ����
            randomPosY = Random.Range(-4f, -0.5f);
            transform.position = new Vector3(returnPosX, randomPosY, 0.1f);
        }
    }
}
