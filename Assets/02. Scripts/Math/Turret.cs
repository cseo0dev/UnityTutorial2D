using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform turretHead;

    private float theta;
    public float rotSpeed = 1f;
    public float rotRange = 60f;

    private bool isTarget;
    public Transform target;

    void Update()
    {
        if (!isTarget)
            TurretIdle();
        else
            LookTarget();
    }

    void TurretIdle()
    {
        theta += Time.deltaTime * rotSpeed;

        float rotY = Mathf.Sin(theta) * rotRange;

        turretHead.localRotation = Quaternion.Euler(0, rotY, 0);
    }

    void LookTarget()
    {
        turretHead.LookAt(target);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player ������!");
            target = other.transform;
            isTarget = true;
        }
    }
}