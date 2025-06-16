using UnityEngine;

public class TownGuard : MonoBehaviour, IMove, IAttack
{
        public void Move()
    {
        Debug.Log("이동");
    }

    public virtual void Attack()
    {
        Debug.Log("공격");
    }
}
