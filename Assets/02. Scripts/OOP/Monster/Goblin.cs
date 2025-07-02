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

    // 거리 체크 통합 & 업데이트문(200 FPS) 자원 낭비로 인하여 코루틴으로 거리 계산 처리 - 몬스터의 선공이 좀 늦을 수 있음
    IEnumerator FindPlayerRoutine()
    {
        while (true)
        {
            yield return null;
            targetDist = Vector3.Distance(transform.position, target.position);

            if (monsterState == MonsterState.IDLE || monsterState == MonsterState.PATROL)
            {
                Vector3 monsterDir = Vector3.right * moveDir; // 몬스터가 바라보는 방향
                Vector3 playerDir = (transform.position - target.position).normalized; // 플레이어가 몬스터를 바라보는 방향
                float dotValue = Vector3.Dot(monsterDir, playerDir);
                isTrace = dotValue < -0.5f && dotValue >= -1f; // 고블린이 플레이어를 바라보고 있는 경우

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
        // 3초동안 가만히 있으면 정찰 상태로 변경
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

            // monsterState = MonsterState.PATROL; // // 직접 바꾸는 방식 (지양)
            ChangeState(MonsterState.PATROL); // 상태 전환을 일관되게 관리하고, 추적과 수정이 쉽도록
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
        // 공격 애니메이션 실행
        isAttack = true;
        animator.SetTrigger("[Trigger] Attack");
        float currAnimLength = animator.GetCurrentAnimatorStateInfo(0).length; // Anim이 짧거나 Exit Time을 주의할 것
        yield return new WaitForSeconds(currAnimLength);

        // Idle 애니메이션 실행 & 타겟 바라보도록
        animator.SetBool("[Bool] IsRun", false);
        var targetDir = (target.position - transform.position).normalized;
        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
        yield return new WaitForSeconds(attackTime - 1f); // 몬스터의 공격 속도에 따라 애니메이션 Idle

        isAttack = false;
        animator.SetBool("[Bool] IsRun", true);
        ChangeState(MonsterState.TRACE);
    }
}
