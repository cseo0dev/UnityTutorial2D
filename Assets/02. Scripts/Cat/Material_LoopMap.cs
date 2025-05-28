using UnityEngine;

public class Material_LoopMap : MonoBehaviour
{
    // private���� �ν����Ϳ��� �� ����
    private Renderer renderer;

    public float offsetSpeed = 0.1f;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // 2D���� Vector2�� (Ÿ�Կ� �°� �����ϸ� ��!)
        Vector2 offset = Vector2.right * offsetSpeed * Time.deltaTime;

        // Texture�� Offset�� �����ϰڴ�.
        // MainTex�� ���̴� ������
        renderer.material.SetTextureOffset("_MainTex", renderer.material.mainTextureOffset + offset);
    }
}