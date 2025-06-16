using UnityEngine;

public class WirelessEarPhone : EarPhone
{
    public float batterySize;
    public bool isWireLessCharged;
    public bool isNoiseCancelling;

    public void Charged()
    {
        string msg = isWireLessCharged ? "���� ����" : "���� ����";
        Debug.Log(msg);

        //if (isWireLessCharged)
        //    Debug.Log("���� ����");
        //else
        //    Debug.Log("���� ����");
    }

    public virtual void NoiseCanceling()
    {
        isNoiseCancelling = !isNoiseCancelling;

        string msg = isNoiseCancelling ? "������ ĵ���� On" : "������ ĵ���� Off";
        Debug.Log(msg);
    }
}
