using UnityEngine;
using DevA;

public class ProgrammerB : MonoBehaviour
{
    //ProgrammerA pA = new ProgrammerA();
    public ProgrammerA pA; // ����Ƽ������ �̹� ��üȭ �Ǿ��� ������ new �����ڸ� ������� ����

    void Start()
    {
        //pA.number1 = 10; // private�� �Ұ���
        pA.number2 = 20; // public�̶� ����
        //pA.number3 = 30; // private�� �Ұ���
        //pA.number4 = 40; // ����Ƽ �ν�����â�� �ƴϿ��� �Ұ���
        //pA.number5 = 50; // ����Ƽ �ν�����â�� �ƴϿ��� �Ұ���
    }

}
