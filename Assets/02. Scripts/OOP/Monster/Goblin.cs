using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Goblin : MonsterCore
{
    private float timer;
    private float idleTime, patrolTime;
    // private float percent;
    // private Vector3 startPos, endPos;

    private float traceDist = 5f;
    private float attackDist = 1.5f;

    private bool isAttack;

    void Start()
    {
        Init(30f, 3f, 2f, 10f);
        StartCoroutine(FindPlayerRoutine());
    }

    protected override void Init(float hp, float speed, float attackTime, float atkDamage)
    {
        base.Init(hp, speed, attackTime, atkDamage);
        idleTime = Random.Range(1f, 5f);
    }

    // �Ÿ� üũ ���� & ������Ʈ��(200 FPS) �ڿ� ����� ���Ͽ� �ڷ�ƾ���� �Ÿ� ��� ó�� - ������ ������ �� ���� �� ����
    IEnumerator FindPlayerRoutine()
    {
        while (true)
        {
            yield return null;
            targetDist = Vector3.Distance(transform.position, target.position);

            if (monsterState == MonsterState.IDLE || monsterState == MonsterState.PATROL)
            {
                Vector3 monsterDir = Vector3.right * moveDir; // ���Ͱ� �ٶ󺸴� ����
                Vector3 playerDir = (transform.position - target.position).normalized; // �÷��̾ ���͸� �ٶ󺸴� ����
                float dotValue = Vector3.Dot(monsterDir, playerDir);
                isTrace = dotValue < -0.5f && dotValue >= -1f; // ����� �÷��̾ �ٶ󺸰� �ִ� ���

                if (targetDist <= traceDist && isTrace)
                {
                    animator.SetBool("[Bool] IsRun", true);
                    ChangeState(MonsterState.TRACE);
                }
            } 
            else if (monsterState == MonsterState.TRACE)
            {
                if (targetDist > traceDist)
                {
                    timer = 0f;
                    idleTime = Random.Range(1f, 5f);
                    animator.SetBool("[Bool] IsRun", false);

                    ChangeState(MonsterState.IDLE);
                }

                if (targetDist < attackDist)
                {
                    ChangeState(MonsterState.ATTACK);
                }
            }
        }
    }

    public override void Idle()
    {
        // 3�ʵ��� ������ ������ ���� ���·� ����
        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            hpBar.transform.localScale = new Vector3(moveDir, 1, 1);

            patrolTime = Random.Range(1f, 5f);
            animator.SetBool("[Bool] IsRun", true);

            //startPos = transform.position;
            //endPos = startPos + Vector3.right * moveDir * patrolTime;

            // monsterState = MonsterState.PATROL; // // ���� �ٲٴ� ��� (����)
            ChangeState(MonsterState.PATROL); // ���� ��ȯ�� �ϰ��ǰ� �����ϰ�, ������ ������ ������
        }
    }

    public override void Patrol()
    {
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;
        // transform.position = Vector3.Lerp(startPos, endPos, percent); // �������, ��ǥ ��ġ, ����

        timer += Time.deltaTime;
        if (timer >= patrolTime)
        {
            timer = 0f;
            idleTime = Random.Range(1f, 5f);
            animator.SetBool("[Bool] IsRun", false);

            ChangeState(MonsterState.IDLE);
        }
    }

    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized;
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime;

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
    }

    public override void Attack()
    {
        if (!isAttack)
            StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        // ���� �ִϸ��̼� ����
        isAttack = true;
        animator.SetTrigger("[Trigger] Attack");
        float currAnimLength = animator.GetCurrentAnimatorStateInfo(0).length; // Anim�� ª�ų� Exit Time�� ������ ��
        yield return new WaitForSeconds(currAnimLength);

        // Idle �ִϸ��̼� ���� & Ÿ�� �ٶ󺸵���
        animator.SetBool("[Bool] IsRun", false);
        var targetDir = (target.position - transform.position).normalized;
        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
        yield return new WaitForSeconds(attackTime - 1f); // ������ ���� �ӵ��� ���� �ִϸ��̼� Idle

        isAttack = false;
        animator.SetBool("[Bool] IsRun", true);
        ChangeState(MonsterState.TRACE);
    }
}
