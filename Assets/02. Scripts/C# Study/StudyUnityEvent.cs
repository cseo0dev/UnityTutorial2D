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

    // 켜질 때 마다 1번 실행
    void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // 꺼질 때 마다 1번 실행
    void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    void Update()
    {

    }
}