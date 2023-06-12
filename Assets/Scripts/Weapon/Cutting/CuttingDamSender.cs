using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingDamSender : DamageSender
{
    [SerializeField]
    protected CuttingCtrl cuttingCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCuttingCtrl();
    }

    protected virtual void LoadCuttingCtrl()
    {
        if (this.cuttingCtrl != null) return;
        this.cuttingCtrl = GetComponentInParent<CuttingCtrl>();
    }
}
