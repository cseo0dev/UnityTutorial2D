using UnityEngine;

public class StudyPolygon : MonoBehaviour
{
    void Start()
    {
        // 데이터(점)가 들어갈 mesh 타입의 변수 생성
        Mesh mesh = new Mesh();

        // 점 4개 찍기
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
        };

        // 삼각형 순서
        int[] triangles = new int[]
        {
            0, 2, 1,
            2, 3, 1,
        };

        // uv = 면을 감싸는 표면
        Vector2[] uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };

        // Mesh에 위에서 만든 점, 삼각형, uv 데이터를 적용
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        // MeshFilter에 Mesh 데이터를 적용
        MeshFilter meshFilter = this.gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        // MeshRenderer에 Material 적용
        MeshRenderer meshRenderer = this.gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
    }
}
