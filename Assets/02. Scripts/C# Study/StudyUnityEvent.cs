using System;
using UnityEngine;

public class StudyUnityEvent : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake");
    }

    void Start()
    {
        Debug.Log("Start");
    }

    // ���� �� ���� 1�� ����
    void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // ���� �� ���� 1�� ����
    void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    void Update()
    {

    }
}