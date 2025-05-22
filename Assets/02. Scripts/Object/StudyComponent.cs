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


        //obj = GameObject.Find("Main Camera"); // Main Camera 오브젝트를 찾아서 할당하는 기능

        //// Player라는 Tag를 가진 게임오브젝트를 찾아서 obj에 할당
        //obj = GameObject.FindGameObjectWithTag("Player");
        //objTf = GameObject.FindGameObjectWithTag("Player").transform;

        //// obj의 GameObject 활성상태를 False
        //obj.SetActive(false);

        //// 형 변환
        //objTf.gameObject.SetActive(false);

        //// obj의 MedshRenderer에 접근해서 활성상태를 False로 변경하겠다.
        //obj.GetComponent<MeshRenderer>().enabled = false;

        //Debug.Log($"<color=#FF0000>이름 : {obj.name}"); // 게임오브젝트의 이름
        //Debug.Log($"태그 : {obj.tag}"); // 게임오브젝트의 태그
        //Debug.Log($"위치 : {obj.transform.position}"); // 게임오브젝트의 Transform 컴포넌트의 위치
        //Debug.Log($"회전 : {obj.transform.rotation}"); // 게임오브젝트의 Transform 컴포넌트의 회전
        //Debug.Log($"크기 : {obj.transform.localScale}"); // 게임오브젝트의 Transform 컴포넌트의 크기

        //// MeshFilter 컴포넌트에 접근해서 mesh를 Log 메세지로 출력하는 기능
        //Debug.Log($"Mesh 데이터 : {obj.GetComponent<MeshFilter>().mesh}");

        //// MeshRenderer 컴포넌트에 접근해서 material을 Log 메세지로 출력하는 기능
        //Debug.Log($"Meterial 데이터 : {obj.GetComponent<MeshRenderer>().material}");
    }
}