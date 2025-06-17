// 번거로운 작업을 제너릭으로 해결
//public class Factory : MonoBehaviour
//{
//    public GameObject prefab;
//    public Monster monster;
//    public Orc orc;
//    public Goblin goblin;
//}

using UnityEngine;

public class Factory<T> : MonoBehaviour
{
    public T prefab;

    public Factory()
    {
        Debug.Log($"Factory는 {typeof(T)} 타입 입니다.");
    }
}