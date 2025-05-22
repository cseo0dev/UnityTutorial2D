using UnityEngine;

public class StudyGameObject : MonoBehaviour
{
    public GameObject prefab;

    //public Vector3 pos;
    //public Quaternion rot;

    void Start()
    {
        CreateREPO();
    }
        
    /// <summary>
    /// REPO 캐릭터를 생성하고 이름을 변경하는 기능 (함수를 설명할 때에는 /// 주석을 사용함)
    /// </summary>
    public void CreateREPO()
    {
        GameObject obj = Instantiate(prefab);
        obj.name = "R.E.P.O 캐릭터";

        Debug.Log($"{obj.name}이 생성되었습니다.");

        Transform objTf = obj.transform;

        int count = objTf.childCount;

        //Debug.Log($"캐릭터의 자식 오브젝트의 수 : {obj.transform.childCount}");
        //Debug.Log($"캐릭터의 자식 오브젝트의 수 : {objTf.childCount}");
        Debug.Log($"캐릭터의 자식 오브젝트의 수 : {count}");

        Debug.Log($"캐릭터의 첫번째 자식 오브젝트의 이름 : {objTf.GetChild(0).name}");

        Debug.Log($"캐릭터의 마지막 자식 오브젝트의 이름 : {objTf.GetChild(obj.transform.childCount - 1).name}");
    }
}

