using UnityEngine;

public class MathCircle : MonoBehaviour
{
    private float theta;

    void Update()
    {
        theta += Time.deltaTime;

        float x = Mathf.Cos(theta);
        float y = Mathf.Sin(theta);

        Vector2 pos = new Vector2(x, y);

        transform.position = pos;
    }
}