using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinMovement.coinCount++;
            Debug.Log($"������� {CoinMovement.coinCount} ���� ȹ��");
            Destroy(this.gameObject);
        }
    }
}
