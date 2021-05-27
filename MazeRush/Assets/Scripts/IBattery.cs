using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattery
{
    float GetCharge();

    void DoCharge(GameObject phone);

    void DrainBattery(float LightLevel);

    void SetBattery(float BatteryLevel);
}
