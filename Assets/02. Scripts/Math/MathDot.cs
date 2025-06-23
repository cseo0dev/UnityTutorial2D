using UnityEngine;

public class MathDot : MonoBehaviour
{
    public Vector3 vecA = new Vector3(1, 0, 0); // Vector Right
    public Vector3 vecB = new Vector3(0, 1, 0); // Vector Up

    void Start()
    {
        // Cos(theta) 값
        float result = Vector3.Dot(vecA, vecB);

        // 각도 값
        float result2 = Vector3.Angle(vecA, vecB);

        Debug.Log($"벡터의 내적(Cos) : {result}");
        Debug.Log($"벡터의 내적(각도) : {result2}");
    }
}