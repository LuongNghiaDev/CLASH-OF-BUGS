using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingRotate : CuttingParent
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 150f;
    }

    protected override void Rotate()
    {
        transform.Rotate(Vector3.forward * this.speed * Time.deltaTime);
    }
}
