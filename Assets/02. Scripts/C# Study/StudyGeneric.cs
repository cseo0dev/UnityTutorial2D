using UnityEngine;

public class StudyGeneric : MonoBehaviour
{
    public void CreateAccount(string name)
    {
        int dummyAge = 20;
        CreateAccount(name, dummyAge);
    }

    public void CreateAccount(string name, int age)
    {
        string dummyPhoneNumber = "01012345678";
        CreateAccount(name, age, dummyPhoneNumber);
    }

    public void CreateAccount(string name, int age, string phoneNumber)
    {
        string dummyMail = "HelloUnity@unity.com";
        CreateAccount(name, age, phoneNumber, dummyMail);
    }

    public void CreateAccount(string name, int age, string phoneNumber, string eMail)
    {
        // 계정 생성
    }
}