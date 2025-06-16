using UnityEngine;

public class TownPerson : MonoBehaviour, IMove, ITalk
{
    public float hp;
    public float moveSpeed;

    public void Move()
    {
        Debug.Log("이동");
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }

    public virtual void Attack()
    {
        Debug.Log("공격");
    }
}
