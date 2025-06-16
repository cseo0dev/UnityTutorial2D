using UnityEngine;

public class StudySwitch : MonoBehaviour
{
    // 열거형 생성
    public enum CalculationType { Plus, Minus, Multiply, Divide };

    public CalculationType CalculationVal = CalculationType.Plus;

    public int input1, input2, result;

    void Start()
    {
        result = Calculation();
        Debug.Log($"계산 결과 : {result}");
    }

    // void는 return 값이 없기 때문에 int 자료형 사용
    private int Calculation()
    {
        switch (CalculationVal) // Alt + Enter : 케이스문 자동 완성
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
