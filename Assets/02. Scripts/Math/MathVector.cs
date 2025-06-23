using UnityEngine;

public class MathVector : MonoBehaviour
{
    public Vector3 vecA = new Vector3(3, 0, 0);
    public Vector3 vecB = new Vector3(0, 4, 0);

    void Start()
    {
        float size = Vector3.Magnitude(vecA + vecB);
        Debug.Log($"Magnitude : {size}"); // 5 출력

        float distance = Vector3.Distance(vecA, vecB);
        Debug.Log($"Distance : {distance}"); // 5 출력

        // 루트 생략
        float size2 = Vector3.SqrMagnitude(vecA + vecB);
        Debug.Log($"SqrMagnitude : {size2}"); // 25 출력
    }
}