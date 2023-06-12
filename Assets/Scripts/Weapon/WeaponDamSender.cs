using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamSender : DamageSender
{

    [SerializeField]
    protected CannonCtrl cannonCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCannonCtrl();
    }

    protected virtual void LoadCannonCtrl()
    {
        if (this.cannonCtrl != null) return;
        this.cannonCtrl = GetComponentInParent<CannonCtrl>();
    }
    
}
