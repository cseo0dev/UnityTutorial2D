using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed;

    public bool isStop; // false (기본값)

    void Start()
    {
        rotSpeed = 0f;
    }

    void Update()
    {
        // 룰렛은 자기 자신이 돌아야하니까 Rotate 사용
        transform.Rotate(Vector3.forward * rotSpeed);

        // 마우스 왼쪽을 클릭하였을 때 회전하도록 설정 (Down 함수라 한번만 실행)
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 5f;
        }

        // 스페이스바를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            isStop = true;
        }

        if (isStop == true)
        {
            rotSpeed *= 0.99f;

            if (rotSpeed < 0.01f)
            {
                // 속도를 점점 감소시키는 기능
                rotSpeed = 0f;
                isStop = false;
            }
        }
    }
}
