using UnityEngine;

public class Orc : Monster, IMove
{
    public float hp;
    public float moveSpeed;

    public void Move()
    {
        Debug.Log("이동");
    }

    public void Attack()
    {
        Debug.Log("공격");
    }

    public override void SetHealth()
    {
        hp = 100f;
    }
}
