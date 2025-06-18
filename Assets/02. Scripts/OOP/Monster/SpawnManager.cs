using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // 몬스터 종류가 이미 정해진 경우
    [SerializeField] private GameObject[] monsters;

    // 코인 구현 (1개용)
    // [SerializeField] private GameObject coinPrefab;
    // 코인 구현 (여러개)
    [SerializeField] private GameObject[] items;

    // 3초마다 몬스터를 랜덤으로 생성하는 기능
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            // 몬스터 종류 랜덤으로 나타나도록
            var randomIndex = Random.Range(0, monsters.Length);

            // 몬스터가 랜덤 위치에 나타나도록
            var randomX = Random.Range(-8, 9);
            var randomY = Random.Range(-3, 5);
            var createPos = new Vector3(randomX, randomY, 0);

            Instantiate(monsters[randomIndex], createPos, Quaternion.identity); // 몬스터 생성 -> 원점에 생성
        }
    }

    public void DropCoin(Vector3 dropPos)
    {
        var randomX = Random.Range(0, items.Length);

        // 아이템 생성
        GameObject item = Instantiate(items[randomX], dropPos, Quaternion.identity);

        // 아이템 뿌리기 - 방향 구현
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);

        // 아이템 뿌리기 - 회전 구현
        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }
}