using UnityEngine;

public class Orc : Monster, IMove
{
    public float hp;
    public float moveSpeed;

    public void Move()
    {
        Debug.Log("�̵�");
    }

    public void Attack()
    {
        Debug.Log("����");
    }

    public override void SetHealth()
    {
        hp = 100f;
    }
}
