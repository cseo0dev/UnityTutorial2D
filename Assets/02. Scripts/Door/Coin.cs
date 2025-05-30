using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinMovement.coinCount++;
            Debug.Log($"ÇöÀç±îÁö {CoinMovement.coinCount} ÄÚÀÎ È¹µæ");
            Destroy(this.gameObject);
        }
    }
}
