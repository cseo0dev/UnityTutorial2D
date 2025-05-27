
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;

    // �ٴ��� ������ �ν����Ϳ��� ��ġ ��������� ��
    public Vector3 returnPos = new Vector3(30f, 1.5f, 0f);

    //void Start()
    //{
    //    // ��� �̹����� ���̰� 30�̱� ������ x = 30f
    //    returnPos = new Vector3(30f, transform.position.y, 0f);
    //}

    void Update()
    {
        // ����� �������� �̵��ϴ� ���
        // deltaTime ���� ��ǻ�� ���ɿ� ���� ���� �ٸ��� ������ fixedDeltaTime�� ���
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        Debug.Log(Time.fixedDeltaTime);

        // �̹����� x�� ���� -30�� �Ѵ� ����
        if (transform.position.x <= -30f)
        {
            // x���� 30���� �ʱ�ȭ
            transform.position = returnPos;
        }
    }
}
