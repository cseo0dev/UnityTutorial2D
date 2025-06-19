using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // ���� ������ �̹� ������ ���
    [SerializeField] private GameObject[] monsters;

    // ���� ���� (1����)
    // [SerializeField] private GameObject coinPrefab;
    // ���� ���� (������)
    [SerializeField] private GameObject[] items;

    private List<Monster> monsterList = new List<Monster>();

    // 3�ʸ��� ���͸� �������� �����ϴ� ���
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            // ���� ���� �������� ��Ÿ������
            var randomIndex = Random.Range(0, monsters.Length);

            // ���Ͱ� ���� ��ġ�� ��Ÿ������
            var randomX = Random.Range(-8, 9);
            var randomY = Random.Range(-3, 5);
            var createPos = new Vector3(randomX, randomY, 0);

            GameObject monster = Instantiate(monsters[randomIndex], createPos, Quaternion.identity); // ���� ���� -> ������ ����
            
            //monsterList.Add(monster.GetComponent<Monster>());
            //Debug.Log($"���� ���� �� : {monsterList.Count}");

            int ranDir = Random.Range(0, 2) > 0 ? 1 : -1;
            
            monster.GetComponent<Monster>().Dir = ranDir;
            monster.GetComponent<Monster>().SetFlip(ranDir);
        }
    }

    public void DropCoin(Vector3 dropPos)
    {
        var randomX = Random.Range(0, items.Length);

        // ������ ����
        GameObject item = Instantiate(items[randomX], dropPos, Quaternion.identity);

        // ������ �Ѹ��� - ���� ����
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);
        //itemRb.AddForce(new Vector2(Random.Range(-2f, 2f), 3f), ForceMode2D.Impulse);

        // ������ �Ѹ��� - ȸ�� ����
        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }
}