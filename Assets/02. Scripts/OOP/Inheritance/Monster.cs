using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageable
{
    public float hp;

    public abstract void SetHealth();

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("¸ó½ºÅÍ Áê±Ý");
    }
}

