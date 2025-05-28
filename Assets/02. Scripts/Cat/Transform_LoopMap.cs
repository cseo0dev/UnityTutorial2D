
using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float returnPosX = 15f;
    public float randomPosY;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        if (transform.position.x <= -returnPosX)
        {
            // Pipe가 랜덤한 높이에 나타나도록 설정
            randomPosY = Random.Range(-8f, -2.5f);
            transform.position = new Vector3(returnPosX, randomPosY, 0.1f);
        }
    }
}
