using UnityEngine;

public class StudyProperty : MonoBehaviour
{
    [Header("�ӵ�")]
    // [SerializeField] = ����Ƽ �����Ϳ����� ���� ����
    [SerializeField]private float moveSpeed = 20f;

    [Space (10)] // ����
    [Header("�ӵ�2")]
    [Range(0, 10)]
    [field: SerializeField]
    // ������Ƽ�� ����Ƽ �����Ϳ� ��Ÿ���� ����
    private float moveSpeed2 = 10f;
    public float MoveSpeed2
    {
        get { return moveSpeed2; }
        set { moveSpeed2 = value; }
    }
}
