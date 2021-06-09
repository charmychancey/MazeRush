using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBattery : ScriptableObject, IBattery
{
    private float Charge = 5.0f;
    private float DrainRate = 5e-6f;
    float IBattery.GetCharge()
    {
        return this.Charge;
    }

    void IBattery.DoCharge(GameObject phone)
    {}

    public void SetBattery(float BatteryLevel)
    {
        this.Charge = BatteryLevel;
    }

    public void DrainBattery(float LightLevel)
    {
        this.Charge -= LightLevel * this.DrainRate;
        // Debug.Log(this.Charge);
    }
}
