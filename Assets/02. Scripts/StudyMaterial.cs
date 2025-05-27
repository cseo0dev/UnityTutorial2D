using UnityEngine;

public class StudyMaterial : MonoBehaviour
{
    public Material mat;

    public string hexCode;

    void Start()
    {
        // Material을 바꾸는 방식이 아님!! XXX
        //this.GetComponent<Material>() = mat;

        // 1. MeshRenderer에 접근해서 머테리얼을 바꾸는 방식
        //this.GetComponent<MeshRenderer>().material = mat;
        //this.GetComponent<MeshRenderer>().sharedMaterial = mat;

        // 2. 머테리얼 자체를 바꾸지 않고 머테리얼 데이터를 바꾸는 방식
        //this.GetComponent<MeshRenderer>().material.color = Color.green; // 적용한 머테리얼의 색상을 바꿔버림
        //this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green; // 쉐어한거 다 바꿔버림

        // 3. 색상을 직접 넣기 (color는 4개의 값이 들어감)
        //this.GetComponent<MeshRenderer>().material.color = new Color(200f, 137f, 70f, 255f); // 이러면 후광이 있기 때문에 rgb 값인 255로 나눠줘야함!
        //this.GetComponent<MeshRenderer>().material.color = new Color(130f / 255f, 20f / 255f, 70f / 255f, 1);

        Material mat = this.GetComponent<MeshRenderer>().material;
        Color outputColor;

        if (ColorUtility.TryParseHtmlString(hexCode, out outputColor))
        {
            mat.color = outputColor;
        }
    }
}