using UnityEngine;

public class StudyProperty : MonoBehaviour
{
    private int number1 = 10;

    // ĸ��ȭ (number1�� private�� ������ �Ұ����Ͽ� ĸ��ȭ?)
    public int Number1
    {
        get
        { 
            return number1;
        }
        set
        {
            number1 = value;
        }
    }

    public int number2 = 20;
}
