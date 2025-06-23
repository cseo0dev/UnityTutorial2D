using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] turretPrefab;

    void OnMouseDown()
    {
        Instantiate(turretPrefab[SetTile.turretIndex], transform.position, Quaternion.identity);        
    }
}