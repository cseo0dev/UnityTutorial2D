using UnityEngine;

public class StudyProperty : MonoBehaviour
{
    [Header("속도")]
    // [SerializeField] = 유니티 에디터에서는 수정 가능
    [SerializeField]private float moveSpeed = 20f;

    [Space (10)] // 간격
    [Header("속도2")]
    [Range(0, 10)]
    [field: SerializeField]
    // 프로퍼티는 유니티 에디터에 나타나지 않음
    private float moveSpeed2 = 10f;
    public float MoveSpeed2
    {
        get { return moveSpeed2; }
        set { moveSpeed2 = value; }
    }
}
