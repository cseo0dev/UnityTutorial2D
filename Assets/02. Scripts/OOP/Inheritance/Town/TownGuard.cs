using UnityEngine;

public class TownGuard : MonoBehaviour, IMove, IAttack
{
        public void Move()
    {
        Debug.Log("�̵�");
    }

    public virtual void Attack()
    {
        Debug.Log("����");
    }
}
