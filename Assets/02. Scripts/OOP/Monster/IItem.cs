using UnityEngine;

public interface IItem
{
    GameObject Obj { get; set; }

    // 모든 아이템은 획득이 가능해야함
    void Get();
}