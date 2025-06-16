using UnityEngine;

public class Door : MonoBehaviour, IDamageable
{
    public float hp = 100f;

    public void Death()
    {
        Debug.Log("���� �ı��Ǿ����ϴ�.");
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"{damage}��ŭ�� ���ظ� �Ծ����ϴ�.");

        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }
}
