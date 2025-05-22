using UnityEngine;
using UnityEngine.Assertions.Must;

public class DestoryEvent : MonoBehaviour
{
    public float destroyTime = 3f;
    
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    private void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}�� �ı��Ǿ����ϴ�.");
    }
}