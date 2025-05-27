
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;

    // 바닥은 유니터 인스펙터에서 위치 수정해줘야 함
    public Vector3 returnPos = new Vector3(30f, 1.5f, 0f);

    //void Start()
    //{
    //    // 배경 이미지의 길이가 30이기 때문에 x = 30f
    //    returnPos = new Vector3(30f, transform.position.y, 0f);
    //}

    void Update()
    {
        // 배경이 왼쪽으로 이동하는 기능
        // deltaTime 값은 컴퓨터 성능에 따라 값이 다르기 때문에 fixedDeltaTime을 사용
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        Debug.Log(Time.fixedDeltaTime);

        // 이미지의 x축 값이 -30을 넘는 순간
        if (transform.position.x <= -30f)
        {
            // x값을 30으로 초기화
            transform.position = returnPos;
        }
    }
}
