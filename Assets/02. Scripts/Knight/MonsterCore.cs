using UnityEngine;
using UnityEngine.UI;

public abstract class MonsterCore : MonoBehaviour, IDamageable
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK }
    public MonsterState monsterState = MonsterState.IDLE; // 안 적어도 IDLE(가장 앞)이 기본값

    public ItemManager itemManager;

    public Transform target;
    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;
    public Image hpBar;

    public float hp;
    public float currHp;

    public float speed;
    public float attackTime;
    public float atkDamage;

    protected float moveDir;
    protected float targetDist;

    protected bool isTrace;
    private bool isDead;

    protected virtual void Init(float hp, float speed, float attackTime, float atkDamage)
    {
        this.hp = hp;
        this.speed = speed;
        this.attackTime = attackTime;
        this.atkDamage = atkDamage;

        itemManager = FindFirstObjectByType<ItemManager>();

        target = GameObject.FindGameObjectWithTag("Player").transform; // 태그가 적을 경우 사용
        // target = FindFirstObjectByType<KnightController_Keyboard>().transform; // 일반적으로 찾는 방법

        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();

        currHp = hp;
        hpBar.fillAmount = currHp / hp;
    }

    void Update()
    {
        if (isDead)
            return;

        switch (monsterState)
        {
            case MonsterState.IDLE:
                Idle();
                break;
            case MonsterState.PATROL:
                Patrol();
                break;
            case MonsterState.TRACE:
                Trace();
                break;
            case MonsterState.ATTACK:
                Attack();
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }

        if (other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(atkDamage);
        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newState)
    {
        if (monsterState != newState) // 몬스터 State가 새로 설정하는 State와 다를경우
            monsterState = newState;
    }

    public void TakeDamage(float damage)
    {
        currHp -= damage;

        hpBar.fillAmount = currHp / hp;

        if (currHp <= 0f)
            Death();
    }

    public void Death()
    {
        isDead = true;
        animator.SetTrigger("[Trigger] Death");
        monsterColl.enabled = false; // 계속 공격하기 때문에 콜라이더를 꺼버림
        monsterRb.gravityScale = 0f; // 콜라이더를 해제해주었기 때문에 중력때문에 떨어짐 -> 중력을 0으로 설정

        // 아이템 드롭 개수 (0 ~ 2)
        int itemCount = Random.Range(1, 3);
        if (itemCount > 0)
        {
            for (int i = 0; i < itemCount; i++)
            {
                itemManager.DropItem(transform.position);
            }
        }
    }
}