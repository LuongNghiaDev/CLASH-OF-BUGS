using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingDamReceiver : DamageReceiver
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

    protected override void OnDead()
    {
        this.cuttingCtrl.gameObject.SetActive(false);
    }
}
