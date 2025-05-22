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
    /// REPO ĳ���͸� �����ϰ� �̸��� �����ϴ� ��� (�Լ��� ������ ������ /// �ּ��� �����)
    /// </summary>
    public void CreateREPO()
    {
        GameObject obj = Instantiate(prefab);
        obj.name = "R.E.P.O ĳ����";

        Debug.Log($"{obj.name}�� �����Ǿ����ϴ�.");

        Transform objTf = obj.transform;

        int count = objTf.childCount;

        //Debug.Log($"ĳ������ �ڽ� ������Ʈ�� �� : {obj.transform.childCount}");
        //Debug.Log($"ĳ������ �ڽ� ������Ʈ�� �� : {objTf.childCount}");
        Debug.Log($"ĳ������ �ڽ� ������Ʈ�� �� : {count}");

        Debug.Log($"ĳ������ ù��° �ڽ� ������Ʈ�� �̸� : {objTf.GetChild(0).name}");

        Debug.Log($"ĳ������ ������ �ڽ� ������Ʈ�� �̸� : {objTf.GetChild(obj.transform.childCount - 1).name}");
    }
}

