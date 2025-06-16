using System.Diagnostics;
using UnityEngine;
using static WirelessEarPhone;

public class WirelessEarPhone2 : WirelessEarPhone
{
    public enum NoiseCancelType { Off, On, Around }
    public NoiseCancelType noiseCancelType;

    void Start()
    {
        name = "AirPod Pro 2";
        price = 30f;
        releaseYear = 2005;
        batterySize = 70f;
    }

    public override void NoiseCanceling()
    {
        noiseCancelType = NoiseCancelType.Off;
        noiseCancelType = NoiseCancelType.On;
        noiseCancelType = NoiseCancelType.Around;

        base.NoiseCanceling();
    }
}