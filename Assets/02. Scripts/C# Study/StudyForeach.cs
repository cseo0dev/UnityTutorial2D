using System.Runtime.CompilerServices;
using UnityEditor.Build;
using UnityEngine;

public class StudyForeach : MonoBehaviour
{
    public string[] persons = new string[5] { "철수", "짱구", "훈이", "맹구", "유리" };

    public string findName;

    void Start()
    {
        FindPerson(findName);
    }

    private void FindPerson(string name)
    {
        bool isFind = false;

        foreach (var person in persons)
        {
            if (person == name)
            {
                isFind = true;
                Debug.Log($"인원 중에 {name}이/가 존재합니다.");
            }
        }

        if(!isFind) Debug.Log($"{name}을/를 찾지 못했습니다.");
    }
}