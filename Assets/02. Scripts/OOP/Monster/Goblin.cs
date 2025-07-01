using System.Collections;
using UnityEngine;

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
        Init(10f, 3f, 2f);
    }

    protected override void Init(float hp, float speed, float attackTime)
    {
        base.Init(hp, speed, attackTime);
    }

    public override void Idle()
    {
        // 3초동안 가만히 있으면 정찰 상태로 변경
        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            patrolTime = Random.Range(1f, 5f);
            animator.SetBool("[Bool] IsRun", true);

            //startPos = transform.position;
            //endPos = startPos + Vector3.right * moveDir * patrolTime;

            // monsterState = MonsterState.PATROL; // // 직접 바꾸는 방식 (지양)
            ChangeState(MonsterState.PATROL); // 상태 전환을 일관되게 관리하고, 추적과 수정이 쉽도록
        }

        if (targetDist <= traceDist && isTrace)
        {
            timer = 0f;
            animator.SetBool("[Bool] IsRun", true);

            ChangeState(MonsterState.TRACE);
        }
    }

    public override void Patrol()
    {
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;
        // transform.position = Vector3.Lerp(startPos, endPos, percent); // 출발지점, 목표 위치, 비율

        timer += Time.deltaTime;
        if (timer >= patrolTime)
        {
            timer = 0f;
            idleTime = Random.Range(1f, 5f);
            animator.SetBool("[Bool] IsRun", false);

            ChangeState(MonsterState.IDLE);
        }

        if (targetDist <= traceDist && isTrace)
        {
            timer = 0f;
            ChangeState(MonsterState.TRACE);
        }
    }

    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized;
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime;

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);

        if (targetDist > traceDist)
        {
            animator.SetBool("[Bool] IsRun", false);

            ChangeState(MonsterState.IDLE);
        }

        if (targetDist < attackDist)
        {
            ChangeState(MonsterState.ATTACK);
        }
    }

    public override void Attack()
    {
        if (!isAttack)
            StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        animator.SetTrigger("[Trigger] Attack");
        yield return new WaitForSeconds(1f);
        animator.SetBool("[Bool] IsRun", false);

        yield return new WaitForSeconds(attackTime - 1f);
        isAttack = false;
        ChangeState(MonsterState.IDLE);
    }
}
