using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    public StudyProperty studyProperty;

    void Start()
    {
        int num1 = studyProperty.Number1;

        studyProperty.Number1 = 100;

        int num2 = studyProperty.number2;
    }
}
