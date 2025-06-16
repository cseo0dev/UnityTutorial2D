using UnityEngine;

public class WirelessEarPhone : EarPhone
{
    public float batterySize;
    public bool isWireLessCharged;
    public bool isNoiseCancelling;

    public void Charged()
    {
        string msg = isWireLessCharged ? "무선 충전" : "유선 충전";
        Debug.Log(msg);

        //if (isWireLessCharged)
        //    Debug.Log("무선 충전");
        //else
        //    Debug.Log("유선 충전");
    }

    public virtual void NoiseCanceling()
    {
        isNoiseCancelling = !isNoiseCancelling;

        string msg = isNoiseCancelling ? "노이즈 캔슬링 On" : "노이즈 캔슬링 Off";
        Debug.Log(msg);
    }
}
