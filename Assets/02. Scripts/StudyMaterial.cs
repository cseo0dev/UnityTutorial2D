using UnityEngine;

public class StudyMaterial : MonoBehaviour
{
    public Material mat;

    public string hexCode;

    void Start()
    {
        // Material�� �ٲٴ� ����� �ƴ�!! XXX
        //this.GetComponent<Material>() = mat;

        // 1. MeshRenderer�� �����ؼ� ���׸����� �ٲٴ� ���
        //this.GetComponent<MeshRenderer>().material = mat;
        //this.GetComponent<MeshRenderer>().sharedMaterial = mat;

        // 2. ���׸��� ��ü�� �ٲ��� �ʰ� ���׸��� �����͸� �ٲٴ� ���
        //this.GetComponent<MeshRenderer>().material.color = Color.green; // ������ ���׸����� ������ �ٲ����
        //this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green; // �����Ѱ� �� �ٲ����

        // 3. ������ ���� �ֱ� (color�� 4���� ���� ��)
        //this.GetComponent<MeshRenderer>().material.color = new Color(200f, 137f, 70f, 255f); // �̷��� �ı��� �ֱ� ������ rgb ���� 255�� ���������!
        //this.GetComponent<MeshRenderer>().material.color = new Color(130f / 255f, 20f / 255f, 70f / 255f, 1);

        Material mat = this.GetComponent<MeshRenderer>().material;
        Color outputColor;

        if (ColorUtility.TryParseHtmlString(hexCode, out outputColor))
        {
            mat.color = outputColor;
        }
    }
}