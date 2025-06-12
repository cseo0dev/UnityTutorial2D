using Unity.VisualScripting;
using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public enum ColliderType {Pipe, Fruit, Both}
    public ColliderType colliderType;

    public GameObject pipe;
    public GameObject fruit;
    public GameObject particle;

    public float moveSpeed = 2f;
    public float returnPosX = 15f;
    public float randomPosY;

    private Vector3 initPos;

    void Awake()
    {
        initPos = transform.localPosition;
    }
    void OnEnable()
    {
        SetRandomSetting(initPos.x);
    }


    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        if (transform.position.x <= -returnPosX)
            SetRandomSetting(returnPosX);
    }

    private void SetRandomSetting(float posX)
    {
        randomPosY = Random.Range(-7.2f, -3.5f);
        transform.position = new Vector3(posX, randomPosY, 1f);

        // �� ������ Switch������ ���ֱ�
        pipe.SetActive(false);
        fruit.SetActive(false);
        particle.SetActive(false);

        // Pipe, Fruit, Both 3���� ���� �ϳ�
        colliderType = (ColliderType)Random.Range(0, 3);

        switch (colliderType)
        { 
            case ColliderType.Pipe:
                pipe.SetActive(true);
                break;

            case ColliderType.Fruit:
                fruit.SetActive(true);
                break;

            case ColliderType.Both:
                pipe.SetActive(true);
                fruit.SetActive(true);
                break;
        }
    }
}