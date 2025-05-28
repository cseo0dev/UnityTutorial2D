using UnityEngine;

public class Material_LoopMap : MonoBehaviour
{
    // private여서 인스펙터에서 못 넣음
    private Renderer renderer;

    public float offsetSpeed = 0.1f;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // 2D여서 Vector2로 (타입에 맞게 설정하면 됨!)
        Vector2 offset = Vector2.right * offsetSpeed * Time.deltaTime;

        // Texture의 Offset을 적용하겠다.
        // MainTex는 쉐이더 변수명
        renderer.material.SetTextureOffset("_MainTex", renderer.material.mainTextureOffset + offset);
    }
}