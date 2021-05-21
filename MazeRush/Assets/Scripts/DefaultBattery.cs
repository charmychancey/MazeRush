using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBattery : IBattery
{
    private float Charge = 80.0f;
    float IBattery.GetCharge()
    {
        return this.Charge;
    }

    void IBattery.DoCharge(GameObject phone)
    {}
}
