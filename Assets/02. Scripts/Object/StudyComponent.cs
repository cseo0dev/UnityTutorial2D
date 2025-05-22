using System.Runtime.Serialization;
using JetBrains.Annotations;
using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;
    //public Transform objTf;

    public Mesh msh;
    public Material mat;

    public void CreateCube()
    {
        obj = new GameObject("Cube");

        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = msh;

        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;

        obj.AddComponent<BoxCollider>();
    }

    void Start()
    {
        //// obj = new GameObject();
        //// obj.name = "Cube";
        //obj = new GameObject("Cube");

        //obj.AddComponent<MeshFilter>();
        //obj.GetComponent<MeshFilter>().mesh = msh;

        //obj.AddComponent<MeshRenderer>();
        //obj.GetComponent<MeshRenderer>().material = mat;

        //obj.AddComponent<BoxCollider>();

        // CreateCube();
        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);


        //obj = GameObject.Find("Main Camera"); // Main Camera ������Ʈ�� ã�Ƽ� �Ҵ��ϴ� ���

        //// Player��� Tag�� ���� ���ӿ�����Ʈ�� ã�Ƽ� obj�� �Ҵ�
        //obj = GameObject.FindGameObjectWithTag("Player");
        //objTf = GameObject.FindGameObjectWithTag("Player").transform;

        //// obj�� GameObject Ȱ�����¸� False
        //obj.SetActive(false);

        //// �� ��ȯ
        //objTf.gameObject.SetActive(false);

        //// obj�� MedshRenderer�� �����ؼ� Ȱ�����¸� False�� �����ϰڴ�.
        //obj.GetComponent<MeshRenderer>().enabled = false;

        //Debug.Log($"<color=#FF0000>�̸� : {obj.name}"); // ���ӿ�����Ʈ�� �̸�
        //Debug.Log($"�±� : {obj.tag}"); // ���ӿ�����Ʈ�� �±�
        //Debug.Log($"��ġ : {obj.transform.position}"); // ���ӿ�����Ʈ�� Transform ������Ʈ�� ��ġ
        //Debug.Log($"ȸ�� : {obj.transform.rotation}"); // ���ӿ�����Ʈ�� Transform ������Ʈ�� ȸ��
        //Debug.Log($"ũ�� : {obj.transform.localScale}"); // ���ӿ�����Ʈ�� Transform ������Ʈ�� ũ��

        //// MeshFilter ������Ʈ�� �����ؼ� mesh�� Log �޼����� ����ϴ� ���
        //Debug.Log($"Mesh ������ : {obj.GetComponent<MeshFilter>().mesh}");

        //// MeshRenderer ������Ʈ�� �����ؼ� material�� Log �޼����� ����ϴ� ���
        //Debug.Log($"Meterial ������ : {obj.GetComponent<MeshRenderer>().material}");
    }
}