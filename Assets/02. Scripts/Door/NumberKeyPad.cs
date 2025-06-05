using UnityEngine;

public class NumberKeyPad : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject doorLock;

    public string password;
    public string keyPadNumber; // 입력한 숫자

    public void OnInputNumber(string numString)
    {
        keyPadNumber += numString;

        Debug.Log($"{numString} 입력되었습니다.\n전체 입력 : {keyPadNumber}");
    }

    public void OnCheckNumber()
    {
        if (keyPadNumber == password)
        {
            Debug.Log("문 열림");

            doorAnim.SetTrigger("Door Open");
            
            doorLock.SetActive(false);
        }
        else
        {
            keyPadNumber = "";
            Debug.Log("비밀번호 오류");
        }
    }
}
