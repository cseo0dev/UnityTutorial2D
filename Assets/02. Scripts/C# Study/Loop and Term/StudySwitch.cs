using UnityEngine;

public class StudySwitch : MonoBehaviour
{
    // ������ ����
    public enum CalculationType { Plus, Minus, Multiply, Divide };

    public CalculationType CalculationVal = CalculationType.Plus;

    public int input1, input2, result;

    void Start()
    {
        result = Calculation();
        Debug.Log($"��� ��� : {result}");
    }

    // void�� return ���� ���� ������ int �ڷ��� ���
    private int Calculation()
    {
        switch (CalculationVal) // Alt + Enter : ���̽��� �ڵ� �ϼ�
        {
            case CalculationType.Plus:
                result = input1 + input2;
                break;

            case CalculationType.Minus:
                result = input1 - input2;
                break;

            case CalculationType.Multiply:
                result = input1 * input2;
                break;

            case CalculationType.Divide:
                result = input1 / input2;
                break;
        }

        return result;
    }
}
