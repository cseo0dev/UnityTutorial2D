using UnityEngine;

public class NumberKeyPad : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject doorLock;

    public string password;
    public string keyPadNumber; // �Է��� ����

    public void OnInputNumber(string numString)
    {
        keyPadNumber += numString;

        Debug.Log($"{numString} �ԷµǾ����ϴ�.\n��ü �Է� : {keyPadNumber}");
    }

    public void OnCheckNumber()
    {
        if (keyPadNumber == password)
        {
            Debug.Log("�� ����");

            doorAnim.SetTrigger("Door Open");
            
            doorLock.SetActive(false);
        }
        else
        {
            keyPadNumber = "";
            Debug.Log("��й�ȣ ����");
        }
    }
}
