using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // ���� ������ �̹� ������ ���
    [SerializeField] private GameObject[] monsters;

    // ���� ���� (1����)
    // [SerializeField] private GameObject coinPrefab;
    // ���� ���� (������)
    [SerializeField] private GameObject[] items;

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

            Instantiate(monsters[randomIndex], createPos, Quaternion.identity); // ���� ���� -> ������ ����
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

        // ������ �Ѹ��� - ȸ�� ����
        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }
}