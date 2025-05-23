using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    public Transform targetTf;
    public Transform turretHead;

    public GameObject bulletPrefab; // ÃÑ¾Ë ÇÁ¸®ÆÕ
    public Transform firePos; // ¹ß»ç À§Ä¡

    public float timer;
    public float cooldownTime;

    void Start()
    {
        targetTf = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        turretHead.LookAt(targetTf);

        timer += Time.deltaTime;
        if (timer >= cooldownTime)
        {
            timer = 0f;
        }

        // ÃÑ¾Ë »ý¼º
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
    }
}
