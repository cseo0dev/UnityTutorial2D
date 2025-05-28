using UnityEngine;
using DevA;

public class ProgrammerB : MonoBehaviour
{
    //ProgrammerA pA = new ProgrammerA();
    public ProgrammerA pA; // 유니티에서는 이미 실체화 되었기 때문에 new 연산자를 사용하지 않음

    void Start()
    {
        //pA.number1 = 10; // private라 불가능
        pA.number2 = 20; // public이라 가능
        //pA.number3 = 30; // private라 불가능
        //pA.number4 = 40; // 유니티 인스펙터창이 아니여서 불가능
        //pA.number5 = 50; // 유니티 인스펙터창이 아니여서 불가능
    }

}
